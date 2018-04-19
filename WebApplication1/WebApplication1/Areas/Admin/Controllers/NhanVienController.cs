using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        CoSoDuLieuDbContext db = null;
        NhanVienDao dao = null;
        //ChuyenNganhDao DaoChuyenNganh = null;
        TaiKhoanDao DaoTaiKhoan = null;
        public NhanVienController()
        {
            db = new CoSoDuLieuDbContext();
            dao = new NhanVienDao();
            //DaoChuyenNganh = new ChuyenNganhDao();
            DaoTaiKhoan = new TaiKhoanDao();
        }
        // GET: GiaoVu/SinhVien
        public ActionResult Index()
        {
            return View(dao.ListNhanVien());
        }

        // GET: GiaoVu/SinhVien/Details/5
        public ActionResult Details(int id)
        {
            return View(dao.NhanVienSinger(id));
        }

        // GET: GiaoVu/SinhVien/Create
        public ActionResult Create()
        {
            //ViewBag.DsChuyenNganh = new SelectList(DaoChuyenNganh.ListChuyenNganh(), "ID_CHUYEN_NGANH", "TEN_CHUYEN_NGANH");
            return View();
        }

        // POST: GiaoVu/SinhVien/Create
        [HttpPost]
        public ActionResult Create(NHAN_VIEN model, FormCollection collection)
        {
            try
            {
                int i = DaoTaiKhoan.AddTaiKhoan(model.TAIKHOAN);
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
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return RedirectToAction("Index");
        }

        // GET: GiaoVu/SinhVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dao.NhanVienSinger(id));
        }

        // POST: GiaoVu/SinhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(NHAN_VIEN model, FormCollection collection)
        {
            try
            {
                int i = dao.SuaNhaVien(model);
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
    }
}