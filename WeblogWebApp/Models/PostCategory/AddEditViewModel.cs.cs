using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Models.PostCategory
{
    public class AddEditViewModel
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان(فارسی)")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string Title { get; set; }

        [Display(Name = "نامک (انگلیسی)")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string Slug { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string Describtion { get; set; }

        [Display(Name = "تصویر بند انگشتی")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public IFormFile ThumbnailImage { get; set; }

        [Display(Name = "دسته بندی مادر:")]
        public List<Entities.Post.PostCategory>? CategoriesSelectList { get; set; }

        public string? ThumbnailImagePath { get; set; }

        public int ParentCatId { get; set; }

    }
}
