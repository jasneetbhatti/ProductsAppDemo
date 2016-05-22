using System.Collections.Generic;
using System.Web.Mvc;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>
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

            return View(products);
        }
    }
}