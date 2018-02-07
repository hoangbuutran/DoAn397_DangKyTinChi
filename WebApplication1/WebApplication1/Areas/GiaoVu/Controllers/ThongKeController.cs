using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.GiaoVu.Models;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class ThongKeController : Controller
    {

        public ActionResult Index()
        {
            PhieuDangKyDao dao = new PhieuDangKyDao();
            ViewBag.DSNamHoc = new SelectList(dao.ListNamHoc(), "ID_NAM_HOC", "TEN_NAM_HOC");
            ViewBag.DSHocKy = new SelectList(dao.ListHocKy(), "ID_HOC_KY", "TEN_HOC_KY");
            return View();
        }

        [HttpPost]
        public ActionResult ThongKe(ThongKeModel thongke)
        {

            return View();
        }

        public ActionResult KetQuaThongKe()
        {
            return View();
        }
    }
}