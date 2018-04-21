using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class NamHocController : LoginChungController
    {
        NamHocDao namHocDao = new NamHocDao();
        // GET: GiaoVu/NamHoc
        public ActionResult Index()
        {
            return View(namHocDao.ListNamHoc());
        }

        // GET: GiaoVu/NamHoc/Details/5
        public ActionResult Details(int id)
        {
            return View(namHocDao.NamHocSinger(id));
        }

        // GET: GiaoVu/NamHoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiaoVu/NamHoc/Create
        [HttpPost]
        public ActionResult Create(NAM_HOC model, FormCollection collection)
        {
            try
            {
                if (namHocDao.AddNamHoc(model) != 0)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: GiaoVu/NamHoc/Edit/5
        public ActionResult Edit(int id)
        {
            return View(namHocDao.NamHocSinger(id));
        }

        // POST: GiaoVu/NamHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(NAM_HOC model, FormCollection collection)
        {
            try
            {
                if (namHocDao.SuaNamHoc(model) != 0)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit", new { id = model.ID_NAM_HOC });
            }
            catch
            {
                return View("Edit", new { id = model.ID_NAM_HOC });
            }
        }

        // GET: GiaoVu/NamHoc/Delete/5
        public ActionResult Delete(int id)
        {
            return View(namHocDao.NamHocDelete(id));
        }

        
    }
}
