using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    public class QLTaiKhoanController : Controller
    {
        private TaiKhoanDao dao;
        public QLTaiKhoanController()
        {
            dao = new TaiKhoanDao();
        }
        [HttpGet]
        public ActionResult DoiMatKhauSinhVien()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhauSinhVien(DoiMatKhauModel model)
        {
            var session = (WebApplication1.Common.SinhVienModel)Session["USER_SESSION"];
            if (model.MatKhauCu == null || model.MatKhauMoi == null)
            {
                ModelState.AddModelError("", "Mời Nhập thông tin đầy đủ");
                return View("DoiMatKhauSinhVien");
            }
            else if (model.MatKhauCu == session.MatKhau)
            {
                bool ketQua = dao.DoiMatKhau(model.MatKhauMoi, model.MatKhauCu, session.TenDangNhap);
                if (ketQua)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else if (model.MatKhauCu != session.MatKhau)
            {
                ModelState.AddModelError("", "Mật Khẩu Củ Không Đúng");
                return View("DoiMatKhauSinhVien");
            }
            return View("DoiMatKhauSinhVien");
        }

        [HttpGet]
        public ActionResult ProfileUser(int id)
        {
            return View(new SinhVienDao().SinhVienSinger(id));
        }
        [HttpGet]
        public ActionResult EditProfileUser(int id)
        {
            return View(new SinhVienDao().SinhVienSinger(id));
        }
        [HttpPost]
        public ActionResult EditProfileUser(SINH_VIEN sinhVien)
        {
            var dao = new SinhVienDao().SuaSinhVienTuSua(sinhVien);
            return RedirectToAction("ProfileUser", "QLTaiKhoan", new { id = sinhVien.ID_SINHVIEN });
        }
    }
}