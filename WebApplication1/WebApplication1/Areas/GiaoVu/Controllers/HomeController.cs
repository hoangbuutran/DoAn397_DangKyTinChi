using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class HomeController : Controller
    {
        // GET: GiaoVu/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}