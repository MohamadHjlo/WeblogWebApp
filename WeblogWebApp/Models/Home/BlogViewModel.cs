namespace WeblogWebApp.Models.Home
{
    public class BlogViewModel
    {
        public List<SinglePostInBlogViewModel> SliderNews { get; set; } 
        public List<SinglePostInBlogViewModel> Location1News { get; set; } 
        public List<SinglePostInBlogViewModel> Location2News { get; set; } 
        public List<SinglePostInBlogViewModel> Location3News { get; set; } 
        public List<SinglePostInBlogViewModel> Location4News { get; set; } 
        public List<SinglePostInBlogViewModel> Location5News { get; set; } 
        public LatestPostViewModel LatestNews { get; set; } 

    }
}
