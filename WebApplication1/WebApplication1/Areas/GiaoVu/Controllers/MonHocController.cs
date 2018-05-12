using Model.EF;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;
using PagedList;

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
        public ActionResult Index(string ChuoiTimKiem, int? page)
        {
            ViewBag.monhoc = new MonHocDao().ListMonHoc().Count();
            if (ChuoiTimKiem == null)
            {
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(dao.ListMonHoc().ToPagedList(pageNumber, pageSize));
            }
            else
            {
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(dao.ListMonHocByCondition(ChuoiTimKiem).ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: GiaoVu/MonHoc/Details/5
        public ActionResult Details(int id)
        {
            return View(dao.MonHocSinger(id));
        }

        //// GET: GiaoVu/MonHoc/Create
        //public ActionResult Create()
        //{
        //    ViewBag.DSChuyenNganh = new SelectList(DaoChuyenNganh.ListChuyenNganh(), "ID_CHUYEN_NGANH", "TEN_CHUYEN_NGANH");
        //    return View();
        //}

        //// POST: GiaoVu/MonHoc/Create
        //[HttpPost]
        //public ActionResult Create(CHUYENNGANH_MONHOC model, FormCollection collection)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            int i = daochuyennganhmonhoc.AddMonHoc(model);
        //            if (i == 1)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Mời Nhập thông tin đầy đủ");
        //            return RedirectToAction("Create");
        //        }
        //    }
        //    catch
        //    {
        //        ModelState.AddModelError("", "Loi error");
        //    }
        //    return View();
        //}

        // GET: GiaoVu/MonHoc/Edit/5
        public ActionResult Edit(int id)
        {
            //ViewBag.DSChuyenNganh = new SelectList(DaoChuyenNganh.ListChuyenNganh(), "ID_CHUYEN_NGANH", "TEN_CHUYEN_NGANH");
            ViewBag.DSChuyenNganh = DaoChuyenNganh.ListChuyenNganh();
            return View(daochuyennganhmonhoc.ChuyenNganhMonHocListWithIdMon(id));
        }

        // POST: GiaoVu/MonHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(IList<CHUYENNGANH_MONHOC> model, FormCollection collection)
        {
            try
            {

                int x = 0;
                int so = model.Count();
                int idMonNew = new int();
                bool? tuChonNew = new bool();
                int? nhomTuChonNew = new int();
                int k = 1;
                for (int i = 0; i < so; i++)
                {
                    if (model[i].ID_CHUYENNGANH != 0 && k == 1)
                    {
                        model[0].ID_CHUYENNGANH = model[i].ID_CHUYENNGANH;
                        idMonNew = daochuyennganhmonhoc.SuaMonHoc(model[0]);
                        tuChonNew = (bool)model[0].MON_HOC.TU_CHON;
                        nhomTuChonNew = (int)model[0].MON_HOC.NHOM_TU_CHON;
                        k++;
                    }
                    else if (model[i].ID_CHUYENNGANH != 0 && i != 0)
                    {
                        model[i].ID_MONHOC = idMonNew;
                        daochuyennganhmonhoc.SuaMonHoc(model[i]);
                    }
                    x++;
                }
                if (x == so)
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

        // POST: GiaoVu/MonHoc/Delete/5
        [HttpGet]
        public ActionResult KhoaMo(int id)
        {
            daochuyennganhmonhoc.KhoaMo(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult TrungMon()
        {
            return View();
        }


        // GET: GiaoVu/MonHoc/Create
        public ActionResult CreateMonNhieuNganh()
        {
            ViewBag.DSChuyenNganh = DaoChuyenNganh.ListChuyenNganh();
            ViewBag.DsMon = new SelectList(dao.ListMonHoc(), "TEN_MON_HOC", "TEN_MON_HOC");
            return View();
        }

        // POST: GiaoVu/MonHoc/Create
        [HttpPost]
        public ActionResult CreateMonNhieuNganh(IList<CHUYENNGANH_MONHOC> model, FormCollection collection)
        {
            try
            {
                int x = 0;
                int so = model.Count();
                int idMonNew = new int();
                bool? tuChonNew = new bool();
                int? nhomTuChonNew = new int();
                int k = 1;
                for (int i = 0; i < so; i++)
                {
                    if (model[i].ID_CHUYENNGANH != 0 && k == 1)
                    {
                        model[0].ID_CHUYENNGANH = model[i].ID_CHUYENNGANH;
                        idMonNew = daochuyennganhmonhoc.AddMonHoc(model[0]);
                        if (idMonNew == 0)
                        {
                            return RedirectToAction("TrungMon");
                        }
                        tuChonNew = (bool)model[0].MON_HOC.TU_CHON;
                        nhomTuChonNew = (int)model[0].MON_HOC.NHOM_TU_CHON;
                        k++;
                    }
                    else if (model[i].ID_CHUYENNGANH != 0 && i != 0)
                    {
                        model[i].ID_MONHOC = idMonNew;
                        daochuyennganhmonhoc.AddMonHoc(model[i]);
                    }
                    x++;
                }
                if (x == so)
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
        [HttpPost]
        public ActionResult DeleteRow(IEnumerable<int> MonHocRecordDeletebyId)
        {
            if (MonHocRecordDeletebyId != null)
            {
                foreach (var id in MonHocRecordDeletebyId)
                {
                    var namHoc = dao.MonHocSinger(id);
                    dao.DeleteMult(namHoc);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
