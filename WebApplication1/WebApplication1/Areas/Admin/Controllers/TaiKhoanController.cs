using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/NguoiDung
        public ActionResult Index()
        {
            var daotaikhoan = new TaiKhoanDao().listTaiKhoan();
            return View(daotaikhoan);
        }

        // GET: Admin/NguoiDung/Details/5
        public ActionResult Details(int id)
        {
            var daotaikhoan = new TaiKhoanDao().TaiKhoanSingleWithID(id);
            return View(daotaikhoan);
        }
    }
}
