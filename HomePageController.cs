using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Go_Green_Group_Project.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult GoGreen()
        {
            return View();
        }
    }
}