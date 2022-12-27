using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeblogWebApp.Entities.Post;
using WeblogWebApp.Entities.Post.Enum;
using WeblogWebApp.Models.Post;
using WeblogWebApp.ServiceLayer.Interfaces.Post;
using WeblogWebApp.ServiceLayer.Interfaces.PostCategory;
using WeblogWebApp.ServiceLayer.Interfaces.PostMedia;
using WeblogWebApp.ServiceLayer.Interfaces.PostTag;
using WeblogWebApp.ServiceLayer.Interfaces.User;
using WeblogWebApp.Utilities.Image;
using WeblogWebApp.Utilities.PersianTranslate;

namespace WeblogWebApp.Controllers.Post
{

    public class PostController : Controller
    {

        private readonly IPostService _postService;
        private readonly IPostCategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IPostTagService _tagService;
        private readonly IPostMediaService _postMediaService;

        public PostController(
            IPostService postService,
            IPostCategoryService categoryService,
            IUserService userService,
            IPostTagService tagService,
            IPostMediaService postMediaService
            )
        {
            _postService = postService;
            _categoryService = categoryService;
            _userService = userService;
            _tagService = tagService;
            _postMediaService = postMediaService;
        }

        public async Task<IActionResult> List()
        {
            var posts = await _postService.GetAll();
            return View("/Views/Panel/Post/List.cshtml", posts);
        }

        [HttpGet]
        public IActionResult Add()
        {

            var model = new AddEditViewModel()
            {
                Categories = _categoryService.GetCategoriesForSelectList(),
                Authors = _userService.GetAuthorsForSelectList(),
                Tags = _tagService.GetTagsForSelectList(),
            };
            return View("/Views/Panel/Post/Add.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEditViewModel model)
        {

            #region ValidationInputs
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    isSuccess = false,
                    message = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                });
            }
            if (model.ThunmnailImage != null)
            {

                if (!LimitFileSize.IsValid(model.ThunmnailImage))
                {
                    return Json(new { isSuccess = false, message = "حجم تصویر وارد شده نباید بیشتر از 2 مگابایت باشد" });
                }
            }

            #endregion

            var post = new WeblogWebApp.Entities.Post.Post
            {
                Lead = model.Lead,
                Body = model.Body,
                Excerpt = model.Excerpt,
                AuthorId = model.AuthorId,
                Visible = model.Visible,
                Views = 0,
                Duration = int.Parse(Math.Ceiling((decimal)model.Duration / 150).ToString()),
                ProductId = model.ProductId,
                PersianDate = DateTime.Now.ToShamsi(),
                CatId = model.CatId,
                Title = model.Title,
                Slug = model.Slug,
                EnTitle = model.EnTitle,
                LocationId = model.LocationId,
            };

            var result = _postService.Insert(post);
            if (!result) return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });
            await _postService.Save();


            if (model.TagIds != null && model.TagIds.Select(tagId => _postService.AddPostTags(post.Id, tagId)).Any(addTagResult => !addTagResult))
            {
                return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });
            }


            const string postCoverPath = "/Media/Post/";
            const string postThumbPath = "/Media/Post/Thumb/";

            var dbCoverMediaPath = "";
            var dbThumbMediaPath = "";

            if (model.CoverImage != null)
            {
                var cover = new PostMedia()
                {
                    PostId = post.Id,
                    Image = Guid.NewGuid().ToString() + Path.GetExtension(model.CoverImage.FileName),
                    ImageType = PostImageType.Cover,
                    ImageAlt = model.CoverAlt
                };
                var postCoverInsertResult = _postMediaService.Insert(cover);
                if (!postCoverInsertResult) return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });

                dbCoverMediaPath = cover.Image;
            }
            if (model.ThunmnailImage != null)
            {
                var thumbnail = new PostMedia()
                {
                    PostId = post.Id,
                    Image = Guid.NewGuid().ToString() + Path.GetExtension(model.ThunmnailImage.FileName),
                    ImageType = PostImageType.Thumbnail,
                    ImageAlt = model.ThunmnailAlt
                };
                var postThumbnailInsertResult = _postMediaService.Insert(thumbnail);
                if (!postThumbnailInsertResult) return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });

                dbThumbMediaPath = thumbnail.Image;
            }

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + postThumbPath))) Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + postThumbPath));
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + postCoverPath))) Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + postCoverPath));

            if (model.CoverImage != null)
            {
                ImageHelper.AddImage(model.CoverImage, postCoverPath + dbCoverMediaPath);
            }

            if (model.ThunmnailImage != null)
            {
                ImageHelper.AddImage(model.ThunmnailImage, postThumbPath + dbThumbMediaPath);
            }

            try
            {
                await _postMediaService.Save();
            }
            catch (Exception e)
            {
                throw;
            }

            return Json(new { isSuccess = true, message = "پست با موفقیت افزوده شد!" });

        }


        [HttpPost]
        [Route("ckEditor-file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {

            if (upload.Length <= 0) return null;

            const string postMediaPath = "/Media/Post/";

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            fileName = fileName.Replace(" ", string.Empty);

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), postMediaPath)))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), postMediaPath));
            }


            ImageHelper.AddImage(upload, postMediaPath + fileName);

            var url = postMediaPath + fileName;

            return Json(new { uploaded = true, url });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return NotFound();
            var post = await _postService.GetById(id);

            var coverMediaPath = string.Empty;
            var coverMediaAlt = string.Empty;
            var thumbMediaPath = string.Empty;
            var thumbMediaAlt = string.Empty;
            var postMedia = await _postMediaService.GetPostMediaByPostId(post.Id);
            if (postMedia != null)
            {
                var postMediaCover = postMedia.Where(i => i.ImageType == PostImageType.Cover).FirstOrDefault();
                var postMediaThumb = postMedia.Where(i => i.ImageType == PostImageType.Thumbnail).FirstOrDefault();
                coverMediaPath = postMediaCover?.Image;
                coverMediaAlt = postMediaCover?.ImageAlt;
                thumbMediaPath = postMediaThumb?.Image;
                thumbMediaAlt = postMediaThumb?.ImageAlt;
            }


            var model = new AddEditViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                Slug = post.Slug,
                Lead = post.Lead,
                Excerpt = post.Excerpt,
                AuthorId = post.AuthorId,
                ProductId = post.ProductId,
                Visible = post.Visible,
                Duration = post.Duration,
                Body = post.Body,
                CatId = post.CatId,
                EnTitle = post.EnTitle,
                TagIds = post.PostTags.Select(t => t.TagId).ToList(),
                Categories = _categoryService.GetCategoriesForSelectList(),
                Authors = _userService.GetAuthorsForSelectList(),
                Tags = _tagService.GetTagsForSelectList(),
                Thunmnail = string.IsNullOrWhiteSpace(thumbMediaPath) ? "/Media/Post/Thumb/default-image.png" : "/Media/Post/Thumb/" + thumbMediaPath,
                Cover = string.IsNullOrWhiteSpace(coverMediaPath) ? "/Media/Post/default-image.png" : "/Media/Post/" + coverMediaPath,
                CoverAlt = coverMediaAlt,
                ThunmnailAlt = thumbMediaAlt,
                LocationId = post.LocationId,
            };

            return View("/Views/Panel/Post/Edit.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEditViewModel model)
        {
            #region ValidationInputs

            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    isSuccess = false,
                    message = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                });
            }

            if (model.ThunmnailImage != null)
            {
                if (!LimitFileSize.IsValid(model.ThunmnailImage))
                {
                    return Json(new { isSuccess = false, message = "حجم تصویر بند انگشتی وارد شده نباید بیشتر از 2 مگابایت باشد" });
                }
            }

            #endregion

            var oldPost = await _postService.GetById(model.Id);

            oldPost.Lead = model.Lead;
            oldPost.Body = model.Body;
            oldPost.Excerpt = model.Excerpt;
            oldPost.AuthorId = model.AuthorId;
            oldPost.Visible = model.Visible;
            oldPost.Duration = int.Parse(Math.Ceiling((decimal)model.Duration / 150).ToString());
            oldPost.ProductId = model.ProductId;
            oldPost.CatId = model.CatId;
            oldPost.Title = model.Title;
            oldPost.Slug = model.Slug;
            oldPost.EnTitle = model.EnTitle;
            oldPost.LocationId = model.LocationId;

            var result = _postService.Update(oldPost);
            if (!result)
            {
                return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });
            }

            //شروع بروزرسانی برچسبها
            var removePostTagsResult = await _postService.RemovePostTags(oldPost.Id);

            if (!removePostTagsResult)
            {
                return Json(new { isSuccess = false, message = "خطایی در حذف برچسب های قدیمی، لطفا مجددا تلاش کنید" });
            }

            if (model.TagIds != null && model.TagIds.Select(tagId => _postService.AddPostTags(oldPost.Id, tagId)).Any(addTagResult => !addTagResult))
            {
                return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });
            }

            //پایان بروزرسانی برچسبها

            await _postService.Save();


            ///شروع ذخیره سازی عکس ها

            const string postCoverPath = "/Media/Post/";
            const string postThumbPath = "/Media/Post/Thumb/";

            var dbCoverMedia = oldPost.PostMedias.FirstOrDefault(m => m.ImageType == PostImageType.Cover);

            if (model.CoverImage != null)
            {
                if (dbCoverMedia == null)
                {
                    return Json(new { isSuccess = false, message = "خطا در یافتن  کاور تصویر قبلی  پست" });
                }

                if (!ImageHelper.RemoveOldImage(postCoverPath + dbCoverMedia.Image))
                {
                    return Json(new { isSuccess = false, message = "خطا در یافتن و حذف تصویر قبلی کاور پست" });
                }

                dbCoverMedia.Image = Guid.NewGuid().ToString() + Path.GetExtension(model.CoverImage.FileName);
                dbCoverMedia.ImageAlt = model.CoverAlt;

                ImageHelper.AddImage(model.CoverImage, postCoverPath + dbCoverMedia.Image);
            }

            var dbThumbMedia = oldPost.PostMedias.FirstOrDefault(m => m.ImageType == PostImageType.Thumbnail);

            if (model.ThunmnailImage != null)
            {
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + postThumbPath)))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + postThumbPath));
                }

                if (dbThumbMedia == null)
                {
                    return Json(new { isSuccess = false, message = "خطا در یافتن  تصویر بندانگشتی قبلی  پست" });
                }

                if (!ImageHelper.RemoveOldImage(postThumbPath + dbThumbMedia.Image))
                {
                    return Json(new { isSuccess = false, message = "خطا در یافتن و حذف تصویر بندانگشتی قبلی  پست" });
                }
                dbThumbMedia.Image = Guid.NewGuid().ToString() + Path.GetExtension(model.ThunmnailImage.FileName);
                dbThumbMedia.ImageAlt = model.ThunmnailAlt;

                ImageHelper.AddImage(model.ThunmnailImage, postThumbPath + dbThumbMedia.Image);

            }

            if (!string.IsNullOrWhiteSpace(model.CoverAlt))
            {
                if (dbCoverMedia != null) dbCoverMedia.ImageAlt = model.CoverAlt;
            }

            if (!string.IsNullOrWhiteSpace(model.ThunmnailAlt))
            {
                if (dbThumbMedia != null) dbThumbMedia.ImageAlt = model.ThunmnailAlt;
            }

            _postMediaService.Update(dbCoverMedia);
            _postMediaService.Update(dbThumbMedia);
            await _postMediaService.Save();

            ///پایان ذخیره سازی عکس ها



            ///پایان بروزرسانی سئو


            return Json(new { isSuccess = true, message = "تغییرات پست با موفقیت اعمال شد!" });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return Json(new { isSuccess = true, message = "پست مورد نظر یافت نشد" });

            var result = await _postService.DeleteById(id);
            await _postService.Save();

            if (!result)
                return Json(new { isSuccess = false, message = "خطا در حذف پست ، لطفا مجددا تلاش کنید" });

            return Json(new { isSuccess = true, message = "پست با موفقیت حذف شد!" });

        }


    }
}