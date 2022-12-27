using WeblogWebApp.Entities.Post;

namespace WeblogWebApp.Models.Home
{
    public class SinglePostInBlogViewModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public int Views { get; set; }
        public int StudyTime { get; set; }
        public string Category { get; set; }
        public int CatId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string PersianCreatedAt { get; set; } 
        public PostMedia Media { get; set; }
    }
}
