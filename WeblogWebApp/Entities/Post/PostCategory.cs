using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Entities.Post
{
    public class PostCategory
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "نامک")]
        public string Slug { get; set; }


        [Display(Name = "شناسه دسته مادر")]
        public int? ParentCategoryId { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        [Display(Name = "تصویر دسته بندی")]
        public string Thunmnail { get; set; }


        #region Relations
        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<PostCategory> SubCategories { get; set; }

        public virtual PostCategory ParentCategory { get; set; }

        #endregion

    }
}
