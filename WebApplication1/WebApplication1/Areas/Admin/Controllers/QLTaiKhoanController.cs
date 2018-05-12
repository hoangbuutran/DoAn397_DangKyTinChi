using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Common;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class QLTaiKhoanController : Controller
    {
        private TaiKhoanDao dao;
        public QLTaiKhoanController()
        {
            dao = new TaiKhoanDao();
        }
        [HttpGet]
        public ActionResult DoiMatKhauAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhauAdmin(DoiMatKhauModel model)
        {
            var session = (WebApplication1.Common.SinhVienModel)Session["USER_SESSION"];

            if (model.MatKhauCu == null || model.MatKhauMoi == null)
            {
                ModelState.AddModelError("", "Mời Nhập thông tin đầy đủ");
                return View("DoiMatKhauAdmin");
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
                return View("DoiMatKhauAdmin");
            }
            return View("DoiMatKhauAdmin");
        }

        [HttpGet]
        public ActionResult ProfileUser()
        {
            var session = (WebApplication1.Common.SinhVienModel)Session["USER_SESSION"];
            return View(new NhanVienDao().NhanVienSinger(session.IdSinhVien));
        }
        [HttpGet]
        public ActionResult EditProfileUser(int id)
        {
            return View(new NhanVienDao().NhanVienSinger(id));
        }
        [HttpPost]
        public ActionResult EditProfileUser(NHAN_VIEN nhanVien, HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                Image.SaveAs(HttpContext.Server.MapPath("~/Images/") + Image.FileName);
                nhanVien.Image = "~/Images/" + Image.FileName;
            }
            var dao = new NhanVienDao().SuaNhaVienTuSua(nhanVien);
            return RedirectToAction("ProfileUser", "QLTaiKhoan", new { id = nhanVien.ID_NHANVIEN });
        }
    }
}