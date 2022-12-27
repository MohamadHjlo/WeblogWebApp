using Microsoft.AspNetCore.Mvc;
using WeblogWebApp.Models.PostTag;
using WeblogWebApp.ServiceLayer.Interfaces.PostTag;

namespace WeblogWebApp.Controllers.PostTag
{
    public class PostTagController : Controller
    {
        private readonly IPostTagService _tagService;

        public PostTagController(IPostTagService postService)
        {
            _tagService = postService;
        }
        // GET: Panel/Tag
        
        public async Task<ActionResult> List()
        {
            var tags = await _tagService.GetAll();
            return View("/Views/Panel/PostTag/List.cshtml",tags);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("/Views/Panel/PostTag/Add.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    isSuccess = false,
                    message = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                });
            }
            var tag = new Entities.Post.Tag
            {
                Title = model.Title,
                Slug = model.Slug,
                Description = model.Describtion
            };
            var result = _tagService.Insert(tag);
          
            if (!result)
            {
                return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });
            }
            await _tagService.Save();

            return Json(new { isSuccess = true, message = "برچسب با موفقیت افزوده شد!" });

        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            if (id <= 0) return NotFound();

            var tag = await _tagService.GetById(id);

            var model = new AddEditViewModel
            {
                Id = tag.Id,
                Title = tag.Title,
                Slug = tag.Slug,
                Describtion = tag.Description
            };
            return View("/Views/Panel/PostTag/Edit.cshtml", model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AddEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    isSuccess = false,
                    message = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                });
            }

            var oldTag = await _tagService.GetById(model.Id);

            oldTag.Title = model.Title;
            oldTag.Slug = model.Slug;
            oldTag.Description = model.Describtion;

            var result = _tagService.Update(oldTag);

            if (!result)
            {
                return Json(new { isSuccess = false, message = "خطایی رخ داد، لطفا مجددا تلاش کنید" });
            }

            await _tagService.Save();

            return Json(new { isSuccess = true, message = "تغییرات برچسب با موفقیت اعمال شد!" });

        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return Json(new { isSuccess = true, message = "برچسب مورد نظر یافت نشد" });

            var result = await _tagService.DeleteById(id);
            await _tagService.Save();

            if (!result)
                return Json(new { isSuccess = false, message = "خطا در حذف برچسب ، لطفا مجددا تلاش کنید" });


            return Json(new { isSuccess = true, message = "برچسب با موفقیت حذف شد!" });


        }
    }
}