using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Entities.Post.Enum
{
    public enum PostLocationType
    {
        [Display(Name = "بدون جایگاه")]
        NoLocation = 0,
        [Display(Name = "اسلایدر اصلی")]
        MainSlider = 1,
        [Display(Name = "جایگاه اول")]
        First = 2,
        [Display(Name = "جایگاه دوم")]
        Second = 3,
        [Display(Name = "جایگاه سوم")]
        Third = 4,
        [Display(Name = "جایگاه چهارم")]
        Forth = 5,
        [Display(Name = "جایگاه پنجم")]
        Fifth = 6,
    }
}
