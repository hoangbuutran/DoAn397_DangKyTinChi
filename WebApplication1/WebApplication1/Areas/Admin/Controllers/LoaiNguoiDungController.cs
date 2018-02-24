using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class LoaiNguoiDungController : Controller
    {
        // GET: Admin/LoaiNguoiDung
        public ActionResult Index()
        {
            var model = new QuyenDao().ListQuyen();
            return View(model);
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
                return View("Index");
            }
            return View();
        }

        
    }
}
