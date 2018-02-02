using Model.EF;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Common;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        CoSoDuLieuDbContext db = null;
        PhieuDangKyDao dao = null;
        MonHocDao daoMonHoc = null;
        CT_PhieuDangKyDao daoCTPhieuDK = null;
        public HomeController()
        {
            db = new CoSoDuLieuDbContext();
            dao = new PhieuDangKyDao();
            daoMonHoc = new MonHocDao();
            daoCTPhieuDK = new CT_PhieuDangKyDao();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaoPhieuDangKy()
        {
            ViewBag.DSNamHoc = new SelectList(dao.ListNamHoc(), "ID_NAM_HOC", "TEN_NAM_HOC");
            ViewBag.DSHocKy = new SelectList(dao.ListHocKy(), "ID_HOC_KY", "TEN_HOC_KY");
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult TaoPhieuDangKy(PHIEU_DANG_KY model, FormCollection collection)
        {
            try
            {
                model.TONG_SO_TIN_CHI = 0;
                int i = dao.CreatePhieuDangKy(model);
                // TODO: Add insert logic here
                if (i != 0)
                {
                    return RedirectToAction("TimMonDangKy", "Home", new { id = i });
                }
            }
            catch
            {
                ModelState.AddModelError("", "Loi roi");
                return View();
            }
            return View();
        }

        public ActionResult TimMonDangKy(int id)
        {
            ViewBag.IDPhieuDangKy = id;
            return View();
        }
        public ActionResult TimMonDangKyPost(TimKiemModel model)
        {
            return RedirectToAction("ThemMonVaoPhieuCTH", "Home", new { searchstring = model.chuoitimkiem, idphieu = model.idPhieu });
        }
        [HttpGet]
        public ActionResult ThemMonVaoPhieuCTH(string searchstring, int idphieu)
        {
            ViewBag.IDPhieuDangKy = idphieu;
            ViewBag.MONHOC = daoMonHoc.MonHocSingerwithMaTimKiem(searchstring);
            return View();
        }

        [HttpPost]
        public ActionResult ThemMonVaoPhieuCTH(CT_PHIEU_DANG_KY model)
        {
            int i = daoCTPhieuDK.AddCTPHIEUDANGKY(model);
            return RedirectToAction("TimMonDangKy", "Home", new { id = model.ID_PHIEU_DANG_KY });
        }
        public ActionResult XemChuongTrinhHoc()
        {
            return View();
        }
        public ActionResult XemLichSuDangKy() 
        {
            var IDSinhVien = WebApplication1.Common.Masinhvien.IDSINHVIEN;
            return View(dao.ListPhieuDangKy(IDSinhVien));
        }

    }
}
