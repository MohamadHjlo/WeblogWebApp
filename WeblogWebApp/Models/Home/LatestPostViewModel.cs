using WeblogWebApp.Utilities.Pagination;

namespace WeblogWebApp.Models.Home
{
    public class LatestPostViewModel
    {
        public List<SinglePostInBlogViewModel> LatestNews { get; set; }
        public PaginationHelper.Pager Pagination { get; set; }
    }
}
