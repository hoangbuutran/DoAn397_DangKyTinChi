using Model.EF;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class MonHocController : Controller
    {
        CoSoDuLieuDbContext db = null;
        MonHocDao dao = null;
        ChuyenNganhDao DaoChuyenNganh = null;
        //LoaiMonDao DaoLoaiMon = null;
        public MonHocController()
        {
            db = new CoSoDuLieuDbContext();
            dao = new MonHocDao();
            DaoChuyenNganh = new ChuyenNganhDao();
            //DaoLoaiMon = new LoaiMonDao();
        }

        // GET: GiaoVu/MonHoc
        public ActionResult Index()
        {
            return View(dao.ListMonHoc());
        }

        // GET: GiaoVu/MonHoc/Details/5
        public ActionResult Details(int id)
        {
            return View(dao.MonHocSinger(id));
        }

        // GET: GiaoVu/MonHoc/Create
        public ActionResult Create()
        {
            ViewBag.DSChuyenNganh = new SelectList(DaoChuyenNganh.ListChuyenNganh(), "ID_CHUYEN_NGANH", "TEN_CHUYEN_NGANH");
            //ViewBag.DSLoaiMon = new SelectList(DaoLoaiMon.ListLoaiMon(), "ID_LOAI_MON", "TEN_LOAI_MON");
            return View();
        }

        // POST: GiaoVu/MonHoc/Create
        [HttpPost]
        public ActionResult Create(MON_HOC model, FormCollection collection)
        {
            try
            {
                int i = dao.AddMonHoc(model);
                if (i == 1)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View();
        }

        // GET: GiaoVu/MonHoc/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DSChuyenNganh = new SelectList(DaoChuyenNganh.ListChuyenNganh(), "ID_CHUYEN_NGANH", "TEN_CHUYEN_NGANH");
            //ViewBag.DSLoaiMon = new SelectList(DaoLoaiMon.ListLoaiMon(), "ID_LOAI_MON", "TEN_LOAI_MON");
            return View(dao.MonHocSinger(id));
        }

        // POST: GiaoVu/MonHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(MON_HOC model, FormCollection collection)
        {
            try
            {
                if (dao.SuaMonHoc(model) == 1)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Loi");
                return RedirectToAction("Edit", "MonHoc", new { id = model.ID_MON_HOC });
            }
            return View();
        }

        // POST: GiaoVu/MonHoc/Delete/5
        [HttpPost]
        public void Delete(int id, FormCollection collection)
        {
            dao.XoaMonHoc(id);
        }
    }
}
