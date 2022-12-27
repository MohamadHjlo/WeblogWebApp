using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeblogWebApp.Entities.Post.Enum;

namespace WeblogWebApp.Entities.Post
{
    public class PostMedia
    {

        [Display(Name = "شناسه")]
        public int Id { get; set; }


        [Display(Name = "تصویر ")]
        public string Image { get; set; }

        [Display(Name = "نام متن جایگزین تصویر")]
        public string ImageAlt { get; set; }


        [Display(Name = "نوع تصویر ")]
        public PostImageType ImageType  { get; set; }


        #region Relations
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        #endregion
    }
}
