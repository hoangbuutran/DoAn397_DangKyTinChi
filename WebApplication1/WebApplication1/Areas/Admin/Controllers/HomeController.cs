using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class HomeController : LoginChungController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.quyen = new QuyenDao().ListQuyen();
            ViewBag.giaovu = new TaiKhoanDao().listCountTaiKhoanGiaoVu();
            ViewBag.sinhvien = new TaiKhoanDao().listCountTaiKhoanSinhVien();
            return View();
        }
    }
}