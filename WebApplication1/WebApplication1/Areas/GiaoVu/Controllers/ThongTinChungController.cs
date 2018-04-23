using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class ThongTinChungController : LoginChungController
    {
        // GET: GiaoVu/ThongTinChung
        public ActionResult Index()
        {
            return View();
        }
    }
}