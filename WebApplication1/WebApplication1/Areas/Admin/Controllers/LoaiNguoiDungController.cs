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
    public class LoaiNguoiDungController : LoginChungController
    {
        // GET: Admin/LoaiNguoiDung
        public ActionResult Index()
        {
            var model = new QuyenDao().ListQuyen();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: GiaoVu/MonHoc/Create
        [HttpPost]
        public ActionResult Create(QUYEN model, FormCollection collection)
        {
            try
            {
                int i = new QuyenDao().AddQuyen(model);
                if (i != 0)
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

        // GET: Admin/LoaiNguoiDung/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new QuyenDao().QuyenSinger(id);
            return View(model);
        }

        // POST: Admin/LoaiNguoiDung/Edit/5
        [HttpPost]
        public ActionResult Edit(QUYEN model, FormCollection collection)
        {
            int dao = new QuyenDao().SuaQuyen(model);
            if (dao != 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        
    }
}
