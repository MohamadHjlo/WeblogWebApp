using System.ComponentModel.DataAnnotations;
using WeblogWebApp.Entities.Post;
using WeblogWebApp.Entities.User;

namespace WeblogWebApp.Models.Post
{
    public class AddEditViewModel
    {

        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }


        [Display(Name = "عنوان(فارسی)")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string Title { get; set; }


        [Display(Name = "تیتر")]
        public string Lead { get; set; }


        [Display(Name = "نامک ")]
        public string Slug { get; set; }


        [Display(Name = "عنوان (انگلیسی)")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string EnTitle { get; set; }


        [Display(Name = "لینک تصویر بندانگشتی")]
        public string? Thunmnail { get; set; }

        [Display(Name = "نام تصویر بندانگشتی")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string ThunmnailAlt { get; set; }


        [Display(Name = "تصویر بندانگشتی")]
        public IFormFile? ThunmnailImage { get; set; }

        
        [Display(Name = "نام تصویر کاور")]
        public string? Cover { get; set; }

        [Display(Name = "نام کاور")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string CoverAlt { get; set; }


        [Display(Name = "تصویر کاور")]
        public IFormFile? CoverImage { get; set; }


        [Display(Name = "متن")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string Body { get; set; }


        [Display(Name = "چکیده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public string Excerpt { get; set; }

        [Display(Name = "شناسه دسته بندی")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public int CatId { get; set; }

        [Display(Name = "شناسه جایگاه")]
        public int LocationId { get; set; }

        [Display(Name = " دسته بندی")]
        public List<Entities.Post.PostCategory>? Categories { get; set; }

        [Display(Name = " نویسنده")]
        public List<User>? Authors { get; set; }

        [Display(Name = " برچسب ها")]
        public List<Tag>? Tags { get; set; }

       

        [Display(Name = "شناسه نویسنده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public int AuthorId { get; set; }


        [Display(Name = "شناسه فیلم")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست")]
        public int ProductId { get; set; }

        public List<int>? TagIds { get; set; }


        [Display(Name = "نمایش در سایت")]
        public bool Visible { get; set; }


        [Display(Name = "تعداد بازدید")]
        public int Views { get; set; }


        [Display(Name = "مدت زمان مطالعه")]
        public int Duration { get; set; }

      

    }
}
