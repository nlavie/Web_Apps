using Proj.DAL;
using System.Linq;
using System.Web.Mvc;

namespace Proj.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Blog
        public ActionResult Index()
        {
            var list = db.Posts.ToList();
            list.Reverse();
            return View(list);
        }
        public ActionResult Like()
        {
            ViewBag.Message = "Your like page.";

            return View();
        }
    }
}