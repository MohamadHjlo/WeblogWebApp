using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Entities.Post
{
    public class PostComment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "محتوا")]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "والد")]
        public int ParentId { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }


        [Display(Name = "تایید کننده")]
        public int? Approver { get; set; }

        [Display(Name = "رد کننده")]
        public int? Rejecter { get; set; }

        [Display(Name = "تاریخ تایید")]
        public DateTime? ApproveDate { get; set; }

        [Display(Name = "تاریخ رد")]
        public DateTime? RejectDate { get; set; }

        #region Relations

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int? UserId { get; set; }
        public virtual User.User User { get; set; }

        #endregion
    }
}
