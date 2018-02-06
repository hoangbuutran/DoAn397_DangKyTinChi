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
    public class HomeController : LoginChungController
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
                ModelState.AddModelError("", "Tạo Phiếu không thành công");
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult TimMonDangKy(int id)
        {
            ViewBag.IDPhieuDangKy = dao.PhieuDKSinger(id);
            return View();
        }

        [HttpPost]
        public ActionResult TimMonDangKy(TimKiemModel model)
        {
            return RedirectToAction("ThemMonVaoPhieuCTH", "Home", new { searchstring = model.chuoitimkiem, idphieu = model.idPhieu });
        }

        [HttpGet]
        public ActionResult ThemMonVaoPhieuCTH(string searchstring, int idphieu)
        {
            ViewBag.IDPhieuDangKy = dao.PhieuDKSinger(idphieu);
            ViewBag.MONHOC = daoMonHoc.MonHocSingerwithMaTimKiem(searchstring);
            return View();
        }

        [HttpPost]
        public ActionResult ThemMonVaoPhieuCTH(CT_PHIEU_DANG_KY model)
        {
            int i = daoCTPhieuDK.AddCTPHIEUDANGKY(model);
            if (i != 0)
            {
                return RedirectToAction("TimMonDangKy", "Home", new { id = model.ID_PHIEU_DANG_KY });
            }
            ModelState.AddModelError("", "Không thể đăng kí thêm vì quá 20 chỉ");
            return View();
        }

        public ActionResult XemChuongTrinhHoc()
        {
            return View();
        }

        public ActionResult XemLichSuDangKy()
        {
            var IDSinhVien = (SinhVienModel)Session["USER_SESSION"];
            return View(dao.ListPhieuDangKy(IDSinhVien.IdSinhVien));
        }

        public ActionResult XemChiTietPhieu(int id)
        {
            ViewBag.DsMon = daoCTPhieuDK.DanhSachMonWithIdPhieu(id);
            return View(dao.PhieuDKSinger(id));
        }

    }
}
