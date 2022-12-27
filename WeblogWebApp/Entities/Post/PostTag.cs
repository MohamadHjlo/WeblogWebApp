using System.ComponentModel.DataAnnotations.Schema;

namespace WeblogWebApp.Entities.Post
{
    public class PostTag
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }

    }
}
