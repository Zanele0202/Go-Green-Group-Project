using Go_Green_Group_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Go_Green_Group_Project.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Registration()
        {
           return View();
        }
    }
}