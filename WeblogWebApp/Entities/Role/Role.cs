using System.ComponentModel.DataAnnotations;
using WeblogWebApp.Entities.Role.Enum;

namespace WeblogWebApp.Entities.Role
{
    public class Role 
    {
        public int Id { get; set; }
        [Display(Name = "نام نقش")]
        public string Name { get; set; }

        [Display(Name = "نام فارسی نقش")]
        public string PersianName { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "نوع نقش")]
        public RoleType RoleType { get; set; }

        #region Relations
        public virtual ICollection<User.User> Users { get; set; }


        #endregion
    }
}
