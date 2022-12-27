using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Entities.Role.Enum
{
    public enum RoleType
    {
        [Display(Name = "ادمین")]
        Admin,
        [Display(Name = "نویسنده")]
        Author,
        [Display(Name = "کاربر")]
        User
    }
}
