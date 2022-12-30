using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Models.PostTag
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


        

    }
}
