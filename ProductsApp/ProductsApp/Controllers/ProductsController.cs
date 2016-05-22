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
                        ProductsId = 1,
                        ProductsName = "Xbox",
                        ProductsCategory = "Gaming",
                        ProductsQuantity = 1000
                    },
                    new Product
                    {
                        ProductsId = 2,
                        ProductsName = "Surface",
                        ProductsCategory = "Productivity",
                        ProductsQuantity = 500
                    },
                    new Product
                    {
                        ProductsId = 3,
                        ProductsName = "Kinect",
                        ProductsCategory = "Gaming",
                        ProductsQuantity = 100
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
            var product = _products.First(p => p.ProductsId == id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var selected = _products.First(p => p.ProductsId == product.ProductsId);
            selected.ProductsName = product.ProductsName;
            selected.ProductsCategory = product.ProductsCategory;
            selected.ProductsQuantity = product.ProductsQuantity;

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = _products.First(p => p.ProductsId == id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = _products.First(p => p.ProductsId == id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _products.First(p => p.ProductsId == id);
            _products.Remove(product);
            return RedirectToAction("Index");
        }
    }
}