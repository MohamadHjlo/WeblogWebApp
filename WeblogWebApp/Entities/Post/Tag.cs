using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Entities.Post
{
    public class Tag 
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "نامک")]
        public string Slug { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }

    }
}
