using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MvcStory.Models;

namespace MvcStory.Controllers
{
    public class StoryController : Controller
    {
// ReSharper disable once FieldCanBeMadeReadOnly.Local
        private StoryDbContext _db = new StoryDbContext();

        // GET: /Story/
        public ActionResult Index()
        {
            return View(_db.Stories.ToList());
        }

        // GET: /Story/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var story = _db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: /Story/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Story/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Text,Rating")] Story story)
        {          
            if (ModelState == null || !ModelState.IsValid) return View(story);
            _db.Stories.Add(story);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Story/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = _db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: /Story/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Text")] Story story)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(story).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story);
        }

        // GET: /Story/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = _db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: /Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = _db.Stories.Find(id);
            _db.Stories.Remove(story);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
