using System.Collections.Generic;
using System.Web.Mvc;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Products> products = new List<Products>
            {
                new Products
                {
                    Id = 1,
                    Name = "Xbox",
                    Category = "Gaming",
                    Quantity = 1000
                },
                new Products
                {
                    Id = 2,
                    Name = "Surface",
                    Category = "Productivity",
                    Quantity = 500
                },
                new Products
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