using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class NhanVienController : LoginChungController
    {
        CoSoDuLieuDbContext db = null;
        NhanVienDao dao = null;
        TaiKhoanDao DaoTaiKhoan = null;
        public NhanVienController()
        {
            db = new CoSoDuLieuDbContext();
            dao = new NhanVienDao();
            DaoTaiKhoan = new TaiKhoanDao();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(dao.ListNhanVien());
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(dao.NhanVienSinger(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NHAN_VIEN model, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tentaikhoan1 = model.TEN_NHANVIEN.ToLower();
                    var tentaikhoan2 = dao.RejectMarks(tentaikhoan1);
                    var tentaikhoan3 = tentaikhoan2.Replace(" ", "");
                    var pass = model.DIEN_THOAI.Substring(6);//01266625412
                    var taikhoan = new TAIKHOAN
                    {
                        USERNAME = tentaikhoan3,
                        PASS = pass,
                        ID_QUYEN = 2
                    };
                    int i = DaoTaiKhoan.AddTaiKhoan(taikhoan);
                    if (i != 0)
                    {
                        model.ID_TAI_KHOAN = i;
                        int j = dao.AddNhanVien(model);
                        if (j == 1)
                        {
                            return RedirectToAction("Index");
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mời nhập đầy đủ thông tin");
                    return View(model);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(dao.NhanVienSinger(id));
        }

        [HttpPost]
        public ActionResult Edit(NHAN_VIEN model, FormCollection collection)
        {

            int i = dao.SuaNhaVien(model);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new { id = model.ID_NHANVIEN });
        }
        [HttpGet]
        public ActionResult KhoaMo(int id)
        {

            dao.KhoaMo(id);
            return RedirectToAction("Index");
        }
    }
}