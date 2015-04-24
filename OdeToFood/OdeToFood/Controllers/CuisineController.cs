using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
        
        [Log]
        public ActionResult Search(string name="french")
        {
            throw new Exception("Here is an error!");
            var message = Server.HtmlEncode(name);
            return Content(message);
        }

    }
}
