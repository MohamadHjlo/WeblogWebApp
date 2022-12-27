using Microsoft.AspNetCore.Mvc;
using WeblogWebApp.Models.Post;
using WeblogWebApp.ServiceLayer.Interfaces.PostCategory;
using WeblogWebApp.Utilities.Image;
using AddEditViewModel = WeblogWebApp.Models.PostCategory.AddEditViewModel;

namespace WeblogWebApp.Controllers.PostCategory
{

    public class PostCategoryController : Controller
    {
        private readonly IPostCategoryService _categoryService;

        public PostCategoryController(IPostCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult List()
        {
            var categories = _categoryService.GetAllWithParents();

            return View("/Views/Panel/PostCategory/List.cshtml", categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new Models.PostCategory.AddEditViewModel()
            {
                CategoriesSelectList = _categoryService.GetCategoriesForSelectList()
            };
            return View("/Views/Panel/PostCategory/Add.cshtml", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddEditViewModel model)
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

            if (model.ThumbnailImage != null)
            {
                if (!LimitFileSize.IsValid(model.ThumbnailImage))
                {
                    return Json(new { isSuccess = false, message = "حجم تصویر وارد شده نباید بیشتر از 2 مگابایت باشد" });
                }
            }

            #endregion

            var category = new Entities.Post.PostCategory
            {
                ParentCategoryId = model.ParentCatId == 0 ? (int?)null : model.ParentCatId,
                Title = model.Title,
                Slug = model.Slug,
                Description = model.Describtion,
                Thunmnail = model.ThumbnailImage != null ? Guid.NewGuid().ToString() + Path.GetExtension(model.ThumbnailImage.FileName) : null,
            };

            var result = _categoryService.Insert(category);

            if (!result)
            {
                return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });
            }

            await _categoryService.Save();

            const string catThumbPath = "/Media/PostCategory/Thumb/";
            const string catPath = "/Media/PostCategory/";

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot" + catPath)))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + catPath));
            }

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + catThumbPath)))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + catThumbPath));
            }

            if (model.ThumbnailImage != null)
            {
                ImageHelper.AddImage(model.ThumbnailImage, catThumbPath + category.Thunmnail);
            }


            return Json(new { isSuccess = true, message = "دسته بندی با موفقیت افزوده شد!" });

        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            if (id <= 0) return NotFound();
            var category = await _categoryService.GetById(id);
            var model = new Models.PostCategory.AddEditViewModel()
            {
                Id = category.Id,
                Title = category.Title,
                Slug = category.Slug,
                Describtion = category.Description,
                ThumbnailImagePath = string.IsNullOrWhiteSpace(category.Thunmnail) ? "/Media/PostCategory/default-image.png" : "/Media/PostCategory/Thumb/" + category.Thunmnail,
                ParentCatId = category.ParentCategoryId ?? 0,
                CategoriesSelectList = _categoryService.GetCategoriesForSelectList().Where(c => c.Id != category.Id).ToList()
            };
            return View("/Views/Panel/PostCategory/Edit.cshtml", model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Models.PostCategory.AddEditViewModel model)
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

            if (model.ThumbnailImage != null)
            {

                if (!LimitFileSize.IsValid(model.ThumbnailImage))
                {
                    return Json(new { isSuccess = false, message = "حجم تصویر وارد شده نباید بیشتر از 2 مگابایت باشد" });
                }
            }

            #endregion

            var oldCategory = await _categoryService.GetById(model.Id);

            oldCategory.ParentCategoryId = model.ParentCatId == 0 ? (int?)null : model.ParentCatId;
            oldCategory.Title = model.Title;
            oldCategory.Slug = model.Slug;
            oldCategory.Description = model.Describtion;

            const string catThumbPath = "/Media/PostCategory/Thumb/";


            if (model.ThumbnailImage != null)
            {
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", "/Media/PostCategory")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", catThumbPath));

                }


                if (!ImageHelper.RemoveOldImage(catThumbPath + oldCategory.Thunmnail))
                {
                    return Json(new { isSuccess = false, message = "خطا در یافتن و حذف تصویر قبلی دسته بندی" });
                }

                oldCategory.Thunmnail = Guid.NewGuid().ToString() + Path.GetExtension(model.ThumbnailImage.FileName);


                ImageHelper.AddImage(model.ThumbnailImage, catThumbPath + oldCategory.Thunmnail);
            }

            var result = _categoryService.Update(oldCategory);

            if (!result)
            {
                return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });
            }

            await _categoryService.Save();

            return Json(new { isSuccess = true, message = "تغییرات دسته بندی با موفقیت اعمال شد!" });

        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return Json(new { isSuccess = false, message = "دسته بندی مورد نظر یافت نشد" });

            var category = await _categoryService.GetById(id);
            if (category.SubCategories.Any())
            {
                return Json(new { isSuccess = false, message = "این دسته بندی، دسته بندی مادر تعدادی از دسته بندی ها است، برای حذف باید تمامی دسته بندی های مرتبط نیز حذف شوند، پس از حذف آنها این دسته را حذف کنید" });
            }

            var result = await _categoryService.Delete(category);

            await _categoryService.Save();

            if (!result)
                return Json(new { isSuccess = false, message = "خطا در حذف دسته بندی ، لطفا مجددا تلاش کنید" });

            return Json(new { isSuccess = true, message = "دسته بندی با موفقیت حذف شد!" });

        }
    }
}