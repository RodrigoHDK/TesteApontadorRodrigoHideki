using Apontador_RodrigoHideki.Models;
using System.Linq.Dynamic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace Apontador_RodrigoHideki.Controllers
{
    public class ApontadorController : Controller
    {
       
        private ApontadorDbContext db = new ApontadorDbContext();

        // GET: Livro
        public ActionResult Index(string filter = null, int page = 1,
         int pageSize = 10, string sort = "Id", string sortdir = "DESC")
        {
            var records = new PagedList<Apontador>();
            ViewBag.filter = filter;
            records.Content = db.Apontador
                        .Where(x => filter == null ||
                                (x.Nome.Contains(filter))
                                   || x.Endereco.Contains(filter)                                        
                              )
                        .OrderBy(sort + " " + sortdir)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.Apontador
                         .Where(x => filter == null ||
                               (x.Nome.Contains(filter)) || x.Endereco.Contains(filter)).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }


        // GET: /Apontador/Details/
        public ActionResult Details(int id = 0)
        {
            Apontador apontador = db.Apontador.Find(id);
            if (apontador == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", apontador);
        }

        // GET: /Apontador/Create
        [HttpGet]
        public ActionResult Create()
        {
            var apontador = new Apontador();
            return PartialView("Create", apontador);
        }


        // POST: /Apontador/Create
        [HttpPost]
        public JsonResult Create(Apontador apontador)
        {
            if (ModelState.IsValid)
            {
                db.Apontador.Add(apontador);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(apontador, JsonRequestBehavior.AllowGet);
        }

        // GET: /Apontador/Edit/
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var apontador = db.Apontador.Find(id);
            if (apontador == null)
            {
                return HttpNotFound();
            }

            return PartialView("Edit", apontador);
        }


        // POST: /Apontador/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Apontador apontador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apontador).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", apontador);
        }


        // GET: /Apontador/Delete/
        public ActionResult Delete(int id = 0)
        {
            Apontador apontador = db.Apontador.Find(id);
            if (apontador == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", apontador);
        }


        // POST: /Apontador/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var apontador = db.Apontador.Find(id);
            db.Apontador.Remove(apontador);
            db.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}