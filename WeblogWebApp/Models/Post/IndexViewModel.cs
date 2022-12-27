using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Models.Post
{
    public class IndexViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان فارسی")]
        public string PersianTitle { get; set; }

        [Display(Name = "تیتر")]
        public string Lead { get; set; }

        [Display(Name = "نام فیلم")]
        public string MovieName { get; set; }

        [Display(Name = "نام دسته بندی")]
        public string CatName { get; set; }

        [Display(Name = "برچسب ها")]

        public string Tags { get; set; }

        [Display(Name = "نویسنده پست")]
        public string Author { get; set; }


        [Display(Name = "نمایش در سایت")]

        public bool Visible { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreatedAt { get; set; }
    }
}
