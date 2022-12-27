using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Entities.User
{
    public class User
    {

        public User()
        {
            Activated = true;
            UserName = "_user";
        }

        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(250, ErrorMessage = "{0}‌نمیتواند بیشتر از {1}‌ کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [RegularExpression(@"^(?:(٠٩[٠-٩][٠-٩]{8})|(۰۹[۰-۹][۰-۹]{8})|(09[0-9][0-9]{8}))$", ErrorMessage = "شماره تلفن با فرمت صحیح وارد نشده است")]
        public string Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(100, ErrorMessage = "{0}‌نمیتواند بیشتر از {1}‌ کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "فعال سازی حساب کاربری")]
        public bool Activated { get; set; }

        [Display(Name = "شهر")]
        public string City { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public string ProfilePicture { get; set; }
        #region Relations
        public virtual Role.Role Role { get; set; }

        #endregion
    }
}
