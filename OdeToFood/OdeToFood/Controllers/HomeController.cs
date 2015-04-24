using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();


        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Restaurant
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Name
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Index(string searchTerm=null, int page=1)
        {

            //var model =
            //    from r in _db.Restaurant
            //    orderby r.Reviews.Average(reviews => reviews.rating) descending
            //    select new RestaurantListNewModel
            //    {
            //        ID=r.ID,
            //        Name=r.Name,
            //        City=r.City,
            //        Country=r.Country,
            //        CountOfReviews=r.Reviews.Count()
            //    };
       
                ViewBag.searchTerm = searchTerm;
            
            var model = _db.Restaurant
                .OrderByDescending(r => (r.Reviews.Average(reviews => reviews.Rating)))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))

                .Select(r => new RestaurantListNewModel
                {
                    ID = r.ID,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            else { return View(model); }
        }

        public ActionResult About()
        {   
           

            ViewBag.Message = "Your app description page.";
            ViewBag.Location = "China";
            
            var model = new AboutModel();
            model.Name="DINGQIANG";
            model.Location = "France";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db!=null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
