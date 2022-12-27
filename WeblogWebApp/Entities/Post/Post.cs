using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeblogWebApp.Entities.Post
{
    public class Post 
    {
        public int Id { get; set; }

        [Display(Name = "عنوان فارسی")]
        public string Title { get; set; }

        [Display(Name = "تیتر")]
        public string Lead { get; set; }

        [Display(Name = "نامک")]
        public string Slug { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        public string EnTitle { get; set; }


        [Display(Name = "متن")]
        public string Body { get; set; }

        [Display(Name = "چکیده")]
        public string Excerpt { get; set; }


        [Display(Name = "شناسه نویسنده")]
        public int AuthorId { get; set; }

        [Display(Name = "نمایش در سایت")]
        public bool Visible { get; set; }

        [Display(Name = "شناسه جایگاه")]
        public int LocationId { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Views { get; set; }


        [Display(Name = "مدت زمان مطالعه")]
        public int Duration { get; set; }

        [Display(Name = "تاریخ شمسی ایجاد پست")]
        public string PersianDate { get; set; }

        #region Relations
        [ForeignKey("Product")]
        public int ProductId { get; set; }


        [ForeignKey("PostCategory")]
        public int CatId { get; set; }
        public virtual PostCategory PostCategory { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<PostMedia> PostMedias { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        #endregion

    }
}
