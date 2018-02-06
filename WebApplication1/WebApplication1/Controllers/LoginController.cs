using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(SinhVienModel sinhvien)
        {
            var daoTaiKhoan = new TaiKhoanDao();
            var i = daoTaiKhoan.Login(sinhvien.TenDangNhap, sinhvien.MatKhau);
            if (i == 1)
            {
                var dao = daoTaiKhoan.TaiKhoanSingle(sinhvien.TenDangNhap, sinhvien.MatKhau);
                var sinhviensession = new SinhVienModel();
                sinhviensession.TenDangNhap = dao.USERNAME;
                sinhviensession.MatKhau = dao.PASS;
                sinhviensession.idloainguoidung = dao.ID_QUYEN;
                Session.Add("USER_SESSION", sinhviensession);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else if (i == 2)
            {
                var dao = daoTaiKhoan.TaiKhoanSingle(sinhvien.TenDangNhap, sinhvien.MatKhau);
                var daosinhvien = new SinhVienDao().SinhVienSingerWithIDTaiKhoan(dao.ID_TAI_KHOAN);
                var sinhviensession = new SinhVienModel();
                sinhviensession.IdSinhVien = daosinhvien.ID_SINHVIEN;
                sinhviensession.TenDangNhap = daosinhvien.TAIKHOAN.USERNAME;
                sinhviensession.MatKhau = daosinhvien.TAIKHOAN.PASS;
                sinhviensession.MaSinhVien = daosinhvien.MA_SINH_VIEN;
                Session.Add("USER_SESSION", sinhviensession);
                return RedirectToAction("Index", "Home");//sinh vien
            }
            else if (i == 3)
            {
                var dao = daoTaiKhoan.TaiKhoanSingle(sinhvien.TenDangNhap, sinhvien.MatKhau);
                var sinhviensession = new SinhVienModel();
                sinhviensession.TenDangNhap = dao.USERNAME;
                sinhviensession.MatKhau = dao.PASS;
                sinhviensession.idloainguoidung = dao.ID_QUYEN;
                Session.Add("USER_SESSION", sinhviensession);
                return RedirectToAction("Index", "Home", new { area = "GiaoVu" });
            }
            return View();
        }
    }
}