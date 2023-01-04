using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WeblogWebApp.DataLayer;
using WeblogWebApp.Entities.Post.Enum;
using WeblogWebApp.Entities.Post;
using WeblogWebApp.Models;
using WeblogWebApp.Models.Home;
using WeblogWebApp.Utilities.Pagination;

namespace WeblogWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public ActionResult Index()
        {
            BlogViewModel model = new BlogViewModel();

            var sliderNews = GetPostBaseOnLocation(PostLocationType.MainSlider, PostImageType.Cover, 15);
            var location1 = GetPostBaseOnLocation(PostLocationType.First, PostImageType.Thumbnail, 1);
            var location2 = GetPostBaseOnLocation(PostLocationType.Second, PostImageType.Thumbnail, 1);
            var location3 = GetPostBaseOnLocation(PostLocationType.Third, PostImageType.Thumbnail, 1);
            var location4 = GetPostBaseOnLocation(PostLocationType.Forth, PostImageType.Thumbnail, 1);
            var location5 = GetPostBaseOnLocation(PostLocationType.Fifth, PostImageType.Thumbnail, 6);
            var latesNews = GetLatestPosts(1, 4, 4);

            model.SliderNews = sliderNews;
            model.Location1News = location1;
            model.Location2News = location2;
            model.Location3News = location3;
            model.Location4News = location4;
            model.Location5News = location5;
            model.LatestNews = latesNews;

            //get latest post comments

            return View(model);
        }

        private List<SinglePostInBlogViewModel> GetPostBaseOnLocation(PostLocationType type, PostImageType image, int take = 1, int skip = 0)
        {

            {
                var posts = _db.Posts
                    .Where(i => i.LocationId == (int)type && i.Visible)
                    .Include(p => p.PostMedias)
                    .Include(p => p.PostCategory)
                    .Select(i => new SinglePostInBlogViewModel
                    {
                        Id = i.Id,
                        Slug = i.Slug,
                        Title = i.Title,
                        CatId = i.CatId,
                        Excerpt = i.Excerpt,
                        StudyTime = i.Duration,
                        Views = i.Views,
                        PersianCreatedAt = i.PersianDate,
                        Media = i.PostMedias.Where(p => p.ImageType == image).FirstOrDefault(),
                        Category = i.PostCategory.Title
                    })
                    .Take(take)
                    .ToList();
                return posts;
            }
        }


        public IActionResult CategoryArchive(int id)
        {

            if (id <= 0)
            {
                return NotFound();
            }

            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public IActionResult CategoryArchive(int id, int currentPage = 1, int take = 8, int postPerPage = 8)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            int skipRows = (currentPage - 1) * postPerPage;


            var totalNews = _db.Posts.Count(i => i.Visible && i.CatId == id);
            PaginationHelper.Pager page = new PaginationHelper.Pager(totalNews, currentPage, 8, 5);

            var posts = _db.Posts
                .Include(p => p.PostCategory)
                .Where(i => i.Visible && (i.CatId == id || i.PostCategory.ParentCategoryId == id))
                .Include(p => p.PostMedias)

                .ToList().Select(i => new SinglePostInBlogViewModel
                {
                    Id = i.Id,
                    Slug = i.Slug,
                    Title = i.Title,
                    CatId = i.CatId,
                    Excerpt = i.Excerpt,
                    StudyTime = i.Duration,
                    Views = i.Views,
                    PersianCreatedAt = i.PersianDate,
                    Media = i.PostMedias.Where(p => p.ImageType == PostImageType.Thumbnail).FirstOrDefault(),
                    Category = i.PostCategory.Title
                })
                .OrderBy(m => m.CreatedAt)
                .Skip(skipRows)
                .Take(take)
                .ToList();

            ArchiveViewModel model = new ArchiveViewModel();
            model.Posts = posts;
            model.Pagination = page;

            return PartialView("_CategoryArchive", model);

        }


        public IActionResult TagArchive(int id)
        {

            if (id <= 0)
            {
                return NotFound();
            }

            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public IActionResult TagArchive(int id, int currentPage = 1, int take = 8, int postPerPage = 8)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            ArchiveViewModel model = new ArchiveViewModel();

            int skipRows = (currentPage - 1) * postPerPage;


            var postTags = _db.PostTags.Where(p => p.TagId == id).Select(i => i.PostId).ToList();

            if (postTags.Count > 0)
            {
                var totalNews = _db.Posts
                    .Count(i => i.Visible && postTags.Contains(i.Id));
                PaginationHelper.Pager page = new PaginationHelper.Pager(totalNews, currentPage, 8, 5);

                var posts = _db.Posts
                    .Where(i => i.Visible && postTags.Contains(i.Id))
                    .Include(p => p.PostMedias)
                    .Include(p => p.PostCategory)
                    .ToList().Select(i => new SinglePostInBlogViewModel
                    {
                        Id = i.Id,
                        Slug = i.Slug,
                        Title = i.Title,
                        CatId = i.CatId,
                        Excerpt = i.Excerpt,
                        StudyTime = i.Duration,
                        Views = i.Views,
                        PersianCreatedAt = i.PersianDate,
                        Media = i.PostMedias.Where(p => p.ImageType == PostImageType.Thumbnail).FirstOrDefault(),
                        Category = i.PostCategory.Title
                    })
                    .OrderBy(m => m.CreatedAt)
                    .Skip(skipRows)
                    .Take(take)
                    .ToList();


                model.Posts = posts;
                model.Pagination = page;

            }

            return PartialView("_TagArchive", model);


        }

        public IActionResult GetLatestPostsForPartialView(int currentPage, int take = 1)
        {
            var model = GetLatestPosts(currentPage, 4, 4);
            return PartialView("_LatestNews", model);
        }

        public LatestPostViewModel GetLatestPosts(int currentPage, int take = 1, int postPerPage = 4)
        {

            int skipRows = (currentPage - 1) * postPerPage;

            {
                var totalNews = _db.Posts.Count(i => i.Visible);
                PaginationHelper.Pager page = new PaginationHelper.Pager(totalNews, currentPage, 4, 5);

                var posts = _db.Posts
                    .Where(i => i.Visible)
                    .Include(p => p.PostMedias)
                    .Include(p => p.PostCategory).
                    ToList()
                    .Select(i => new SinglePostInBlogViewModel
                    {
                        Id = i.Id,
                        Slug = i.Slug,
                        Title = i.Title,
                        Excerpt = i.Excerpt,
                        StudyTime = i.Duration,
                        Views = i.Views,
                        PersianCreatedAt = i.PersianDate,
                        Media = i.PostMedias.Where(p => p.ImageType == PostImageType.Thumbnail).FirstOrDefault(),
                        Category = i.PostCategory.Title,
                        CatId = i.CatId,
                    })
                    .OrderBy(m => m.CreatedAt)
                    .Skip(skipRows)
                    .Take(take)
                    .ToList();

                //آماده سازی مدل برای پارشال ویو آخرین اخبار
                LatestPostViewModel latestNewsModel = new LatestPostViewModel();
                latestNewsModel.LatestNews = posts;
                latestNewsModel.Pagination = page;

                return latestNewsModel;
            }
        }

        public IActionResult GetMostViewsPost()
        {

            var posts = _db.Posts
                .Where(i => i.Visible)
                .Include(p => p.PostMedias)
                .Include(p => p.PostCategory)
                .Select(i => new SinglePostInBlogViewModel
                {
                    Id = i.Id,
                    Slug = i.Slug,
                    Title = i.Title,
                    CatId = i.CatId,
                    Excerpt = i.Excerpt,
                    Views = i.Views,
                    PersianCreatedAt = i.PersianDate,
                    Media = i.PostMedias.Where(p => p.ImageType == PostImageType.Thumbnail).FirstOrDefault(),
                })
                .OrderByDescending(m => m.Views)
                .Take(4)
                .ToList();
            return PartialView("_MostViewsNews", posts);

        }

        public IActionResult Single(int id, string slug)
        {

            if (id <= 0) return NotFound();

            SinglePostViewModel model = new SinglePostViewModel();


            var post = _db.Posts.Where(i => i.Id == id)
                .Include(p => p.PostMedias)
                .Include(p => p.PostCategory)
                .Include(p => p.PostTags)
                .ThenInclude(p => p.Tag).FirstOrDefault();
            if (post == null) return NotFound();

            post.Views = post.Views + 1;
            _db.SaveChanges();

            model.Id = post.Id;
            model.Title = post.Title;
            model.Slug = post.Slug;
            model.Lead = post.Lead;
            model.Body = post.Body;
            model.Views = post.Views;
            model.StudyTime = post.Duration;
            model.CatId = post.CatId;
            model.CatName = post.PostCategory.Title;
            model.AuthorId = post.AuthorId;

            model.PostMedia = post.PostMedias.Where(i => i.ImageType == PostImageType.Cover).FirstOrDefault();
            model.ProductId = post.ProductId;
            model.CatId = post.CatId;

            var tags = post.PostTags.Select(i => new { i.Tag.Title, i.Tag.Id });
            Dictionary<int, string> postTags = new Dictionary<int, string>();
            foreach (var item in tags)
            {
                postTags.Add(item.Id, item.Title);
            }

            model.Tags = postTags;

            //post comments


            return View(model);
        }


        public IActionResult GetRelatedPosts(int catId)
        {

            var posts = _db.Posts
                .Where(i => i.CatId == catId && i.Visible)
                .Include(p => p.PostMedias)
                .Include(p => p.PostCategory)
                .Select(i => new SinglePostInBlogViewModel
                {
                    Id = i.Id,
                    Slug = i.Slug,
                    Title = i.Title,
                    Excerpt = i.Excerpt,
                    StudyTime = i.Duration,
                    Views = i.Views,
                    PersianCreatedAt = i.PersianDate,
                    Media = i.PostMedias.Where(p => p.ImageType == PostImageType.Thumbnail).FirstOrDefault(),
                    Category = i.PostCategory.Title,
                    CatId = i.CatId,
                })
                .Take(4)
                .ToList();

            return PartialView("_RelatedNews.cshtml", posts);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}