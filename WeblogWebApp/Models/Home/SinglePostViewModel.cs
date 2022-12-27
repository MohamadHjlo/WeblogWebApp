using WeblogWebApp.Entities.Post;

namespace WeblogWebApp.Models.Home
{
    public class SinglePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public int Views { get; set; }
        public int StudyTime { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string CreatedAt { get; set; }
        public int CatId { get; set; }
        public string CatName { get; set; }
        public int SeoId { get; set; }

        public PostMedia PostMedia { get; set; }

        public Dictionary<int, string> Tags { get; set; }
        public List<Entities.Post.PostComment> postComments { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
