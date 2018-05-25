using Model.DAO;
using System.Web.Mvc;
using WebApplication1.Common;
using CaptchaMvc.HtmlHelpers;

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
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                var daoTaiKhoan = new TaiKhoanDao();
                var i = daoTaiKhoan.Login(sinhvien.TenDangNhap, sinhvien.MatKhau);
                if (i == 1)//ad
                {
                    var dao = daoTaiKhoan.TaiKhoanSingle(sinhvien.TenDangNhap, sinhvien.MatKhau);
                    var daoAdmin = new NhanVienDao().NhanVienSingerWithIDTaiKhoan(dao.ID_TAI_KHOAN);
                    var sinhviensession = new SinhVienModel
                    {
                        IdSinhVien = daoAdmin.ID_NHANVIEN,
                        TenDangNhap = dao.USERNAME,
                        MatKhau = dao.PASS,
                        idloainguoidung = dao.ID_QUYEN
                    };
                    Session.Add("USER_SESSION", sinhviensession);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (i == 3)//sunh vien
                {
                    var dao = daoTaiKhoan.TaiKhoanSingle(sinhvien.TenDangNhap, sinhvien.MatKhau);
                    var daosinhvien = new SinhVienDao().SinhVienSingerWithIDTaiKhoan(dao.ID_TAI_KHOAN);
                    var sinhviensession = new SinhVienModel
                    {
                        IdSinhVien = daosinhvien.ID_SINHVIEN,
                        TenDangNhap = daosinhvien.TAIKHOAN.USERNAME,
                        MatKhau = daosinhvien.TAIKHOAN.PASS,
                        MaSinhVien = daosinhvien.MA_SINH_VIEN,
                        idChuyenNganh = daosinhvien.ID_CHUYEN_NGANH
                    };
                    Session.Add("USER_SESSION", sinhviensession);
                    return RedirectToAction("Index", "Home");//sinh vien
                }
                else if (i == 2)// giao vu
                {
                    var dao = daoTaiKhoan.TaiKhoanSingle(sinhvien.TenDangNhap, sinhvien.MatKhau);
                    var daoGiaoVu = new NhanVienDao().NhanVienSingerWithIDTaiKhoan(dao.ID_TAI_KHOAN);
                    var sinhviensession = new SinhVienModel
                    {
                        IdSinhVien = daoGiaoVu.ID_NHANVIEN,
                        TenDangNhap = dao.USERNAME,
                        MatKhau = dao.PASS,
                        idloainguoidung = dao.ID_QUYEN
                    };
                    Session.Add("USER_SESSION", sinhviensession);
                    return RedirectToAction("Index", "Home", new { area = "GiaoVu" });
                }
                else if (i == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không đúng");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Tài Khoản Không Đúng");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Mã CAPTCHA không đúng");
                return View();
            }
        }
    }
}