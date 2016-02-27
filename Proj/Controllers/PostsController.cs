using Proj.DAL;
using Proj.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Proj.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult DetailsCombined()
        {
            var resault = (from p in db.Posts
                          join c in db.Comments
                          on p.PostID equals c.PostID
                          select new PostComment
                          {
                              post = p,comment =c
                              
                          }).ToList();
            return View(resault);
        }
       

        // GET: Posts
        
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Title,Author,URLWebAddress,PostDate,Text,ImageUrl,VideoUrl")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index","Blog");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Title,Author,URLWebAddress,PostDate,Text,ImageUrl,VideoUrl")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult SearchPost(string Title, string Text, DateTime? PostDate, int rangeInput)
        {
            var posts = from s in db.Posts
                        select s;
            var foundAll = false;
            var foundComment = false;
            var foundDate = false;
            var foundTitle = false;
            var foundText = false;

            // search by ammount of comments
            if (rangeInput > 0)
            {
                var wantedPosts = from post in db.Posts
                                  join comment in db.Comments on post.PostID equals comment.PostID
                                  group post by post.PostID into g
                                  where g.Count() <= rangeInput
                                  select g.Key;

                var wantedPostList = wantedPosts.ToList();
              //  var wantedPostsIds = db.Posts.Where(p => p.Comments.Count <= rangeInput).Select(p => p.PostID ).ToList();

                posts = posts.Where(x => wantedPostList.Any(pid => x.PostID == pid));
                if (posts != null)
                {
                    foundComment = true;
                    foundAll = true;
                }
            }

            // search by Date
            if (!String.IsNullOrEmpty(PostDate.ToString())&&(PostDate.ToString() != "01/01/0001 00:00:00"))
            {
                var fromtime = new DateTime(PostDate.Value.Year, PostDate.Value.Month, PostDate.Value.Day);
                var totime = new DateTime(fromtime.Year,fromtime.Month,fromtime.Day,23,59,59);

                posts = from a in db.Posts
                                  where a.PostDate >= fromtime
                                  where a.PostDate < totime
                                  select a;

                if (posts != null)
                {
                    foundDate = true;
                    foundAll = true;
                }
                if ((foundComment) && (!foundDate))
                    foundAll = false;
            }

            //search by Title
            if (!String.IsNullOrEmpty(Title))
            {
                posts = posts.Where(x => x.Title.Contains(Title));
                foundTitle = true;
                foundAll = true;
                if (((foundComment) || (foundDate)) && (!foundTitle))
                    foundAll = false;
            }

            //search by Text
            if (!String.IsNullOrEmpty(Text))
            {
                posts = posts.Where(x => x.Text.Contains(Text));
                foundText = true;
                foundAll = true;
                if (((foundComment) || (foundDate) || (foundTitle)) && (!foundText))
                    foundAll = false;
            }

            var list = posts.ToList();
            if (!foundAll) 
                list.Clear();
            else
                list.Reverse();
            return PartialView("~/views/Blog/Index.cshtml", list);
        }
    }
}
