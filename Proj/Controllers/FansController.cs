using Proj.DAL;
using Proj.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Proj.Controllers
{
    public class FansController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Fans
        public ActionResult Index()
        {
            return View(db.Fans.ToList());
        }

        // GET: Fans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fans fans = db.Fans.Find(id);
            if (fans == null)
            {
                return HttpNotFound();
            }
            return View(fans);
        }
        



        // GET: Fans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,BirthDate,Seniority,Admin,LoginDetails")] Fans fans)
        {
            if (ModelState.IsValid)
            {
                db.Fans.Add(fans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fans);
        }

        private System.Threading.Tasks.Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            throw new System.NotImplementedException();
        }

        // GET: Fans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fans fans = db.Fans.Find(id);
            if (fans == null)
            {
                return HttpNotFound();
            }
            return View(fans);
        }

        // POST: Fans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Gender,BirthDate,Seniority,Admin,LoginDetails")] Fans fans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fans);
        }

        // GET: Fans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fans fans = db.Fans.Find(id);
            if (fans == null)
            {
                return HttpNotFound();
            }
            return View(fans);
        }

        // POST: Fans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fans fans = db.Fans.Find(id);
            db.Fans.Remove(fans);
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
    }
}
