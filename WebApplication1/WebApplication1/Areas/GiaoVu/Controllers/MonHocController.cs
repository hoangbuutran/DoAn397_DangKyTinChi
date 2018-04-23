using Model.EF;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class MonHocController : LoginChungController
    {
        CoSoDuLieuDbContext db = null;
        MonHocDao dao = null;
        ChuyenNganhMonHocDao daochuyennganhmonhoc = null;
        ChuyenNganhDao DaoChuyenNganh = null;

        public MonHocController()
        {
            db = new CoSoDuLieuDbContext();
            dao = new MonHocDao();
            daochuyennganhmonhoc = new ChuyenNganhMonHocDao();
            DaoChuyenNganh = new ChuyenNganhDao();
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
            return View();
        }

        // POST: GiaoVu/MonHoc/Create
        [HttpPost]
        public ActionResult Create(CHUYENNGANH_MONHOC model, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int i = daochuyennganhmonhoc.AddMonHoc(model);
                    if (i == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mời Nhập thông tin đầy đủ");
                    return RedirectToAction("Create");
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
            return View(daochuyennganhmonhoc.ChuyenNganhMonHocSinger(id));
        }

        // POST: GiaoVu/MonHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(CHUYENNGANH_MONHOC model, FormCollection collection)
        {
            try
            {
                if (daochuyennganhmonhoc.SuaMonHoc(model) == 1)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Loi");
                return RedirectToAction("Edit", "MonHoc", new { id = model.ID_MONHOC });
            }
            return View();
        }

        // POST: GiaoVu/MonHoc/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            daochuyennganhmonhoc.XoaMonHoc(id);
            return RedirectToAction("Index");
        }




        // GET: GiaoVu/MonHoc/Create
        public ActionResult CreateMonNhieuNganh()
        {
            ViewBag.DSChuyenNganh = DaoChuyenNganh.ListChuyenNganh();
            return View();
        }

        // POST: GiaoVu/MonHoc/Create
        [HttpPost]
        public ActionResult CreateMonNhieuNganh(IList<CHUYENNGANH_MONHOC> model, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int x = 0;
                    int so = model.Count();
                    int idMonNew = new int();
                    bool? tuChonNew = new bool();
                    int? nhomTuChonNew = new int();
                    for (int i = 0; i < so; i++)
                    {
                        if (model[i].ID_CHUYENNGANH != 0 && i == 0)
                        {
                            idMonNew = daochuyennganhmonhoc.AddMonHoc(model[i]);
                            tuChonNew = model[i].TU_CHON;
                            nhomTuChonNew = model[i].NHOM_TU_CHON;
                        }
                        else if (model[i].ID_CHUYENNGANH != 0 && i != 0)
                        {
                            model[i].ID_MONHOC = idMonNew;
                            model[i].TU_CHON = tuChonNew;
                            model[i].NHOM_TU_CHON = nhomTuChonNew;
                            daochuyennganhmonhoc.AddMonHoc(model[i]);
                        }
                        x++;
                    }
                    if (x == so)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mời Nhập thông tin đầy đủ");
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View();
        }

    }
}
