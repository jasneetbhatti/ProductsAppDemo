using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDbEntities _db = new ProductDbEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = _db.Products.Find(id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}