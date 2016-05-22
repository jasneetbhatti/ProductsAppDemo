using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product>();

        public ProductsController()
        {
            if (_products.Count == 0)
                _products = new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Xbox",
                        Category = "Gaming",
                        Quantity = 1000
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Surface",
                        Category = "Productivity",
                        Quantity = 500
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Kinect",
                        Category = "Gaming",
                        Quantity = 100
                    }
                };
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            _products.Add(product);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = _products.First(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var selected = _products.First(p => p.Id == product.Id);
            selected.Name = product.Name;
            selected.Category = product.Category;
            selected.Quantity = product.Quantity;

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = _products.First(p => p.Id == id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = _products.First(p => p.Id == id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _products.First(p => p.Id == id);
            _products.Remove(product);
            return RedirectToAction("Index");
        }
    }
}