using WeblogWebApp.Utilities.Pagination;

namespace WeblogWebApp.Models.Home
{
    public class ArchiveViewModel
    {
        public List<SinglePostInBlogViewModel> Posts { get; set; }
        public PaginationHelper.Pager Pagination { get; set; }
    }
}
