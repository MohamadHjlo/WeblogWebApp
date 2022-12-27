using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Models.PostCategory
{
    public class IndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "نامک")]
        public string Slug { get; set; }

        [Display(Name = "شناسه دسته مادر")]
        public int? ParenetId { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "نام ایجاد کننده")]
        public string CreatorName { get; set; }

        [Display(Name = "تصویر بندانگشتی")]
        public string ThumbnailPath { get; set; }

        public bool HasChild { get; set; }

        public Entities.Post.PostCategory? Parent { get; set; }

    }
}
