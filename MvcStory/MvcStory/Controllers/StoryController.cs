using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MvcStory.Models;
using PagedList;

namespace MvcStory.Controllers
{
    public class StoryController : Controller
    {
        private StoryDbContext db = new StoryDbContext();

        // GET: /Story/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var stories = from s in db.Stories
                          select s;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "title_desc":
                    stories = stories.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    stories = stories.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    stories = stories.OrderByDescending(s => s.ReleaseDate);
                    break;
                default:
                    stories = stories.OrderByDescending(s => s.ReleaseDate);
                    break;
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                stories = stories.Where(s => s.Title.Contains(searchString));
            }

            var pageSize = 2;
            var pageNumber = (page ?? 1);
            return View(stories.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Story/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,Title,Text,Date,Rate,Photo")] Story story)
        {
            //var newStory = new Story
            //{
            //    Id = story.Id,
            //    Title = story.Title,
            //    Content = story.Content,
            //    Date = DateTime.Now,
            //    Rate = story.Rate
            //};
            if (ModelState.IsValid)
            {        
               
                if (story.Photo == null)
                {
                    story.Photo = "~/Content/Image/hire_asp_net_developer.png";
                }
                else
                {
                    story.Photo = story.Photo;
                }
                db.Stories.Add(story);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(story);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
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
            Story story = db.Stories.Find(id);
            db.Stories.Remove(story);
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
