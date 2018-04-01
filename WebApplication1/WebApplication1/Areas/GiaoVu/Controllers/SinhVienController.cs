using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class SinhVienController : Controller
    {
        CoSoDuLieuDbContext db = null;
        SinhVienDao dao = null;
        ChuyenNganhDao DaoChuyenNganh = null;
        TaiKhoanDao DaoTaiKhoan = null;
        public SinhVienController()
        {
            db = new CoSoDuLieuDbContext();
            dao = new SinhVienDao();
            DaoChuyenNganh = new ChuyenNganhDao();
            DaoTaiKhoan = new TaiKhoanDao();

        }
        // GET: GiaoVu/SinhVien
        public ActionResult Index()
        {
            return View(dao.ListSinhVien());
        }

        // GET: GiaoVu/SinhVien/Details/5
        public ActionResult Details(int id)
        {
            return View(dao.SinhVienSinger(id));
        }

        // GET: GiaoVu/SinhVien/Create
        public ActionResult Create()
        {
            ViewBag.DsChuyenNganh = new SelectList(DaoChuyenNganh.ListChuyenNganh(), "ID_CHUYEN_NGANH", "TEN_CHUYEN_NGANH");
            return View();
        }

        // POST: GiaoVu/SinhVien/Create
        [HttpPost]
        public ActionResult Create(SINH_VIEN model, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var tentaikhoan1 = model.TEN_SINH_VIEN.ToLower();
                    var tentaikhoan2 = dao.RejectMarks(tentaikhoan1);
                    var tentaikhoan3 = tentaikhoan2.Replace(" ", "");
                    var pass = model.MA_SINH_VIEN.Substring(6);//2121114026
                    model.TAIKHOAN.USERNAME = tentaikhoan3;
                    model.TAIKHOAN.PASS = pass;
                    int i = DaoTaiKhoan.AddTaiKhoan(model.TAIKHOAN);
                    if (i != 0)
                    {
                        model.ID_TAI_KHOAN = i;
                        int j = dao.AddSinhVien(model);
                        if (j == 1)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View("Index");
        }

        // GET: GiaoVu/SinhVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dao.SinhVienSinger(id));
        }

        // POST: GiaoVu/SinhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(SINH_VIEN model, FormCollection collection)
        {
            try
            {
                int i = dao.SuaSinhVien(model);
                if (i == 1)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View("Index");
        }



        // POST: GiaoVu/SinhVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
