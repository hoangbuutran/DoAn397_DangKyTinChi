﻿using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class HomeController : LoginChungController
    {
        // GET: GiaoVu/Home
        public ActionResult Index()
        {
            ViewBag.sinhvien = new SinhVienDao().ListSinhVien().Count();
            ViewBag.monhoc = new MonHocDao().ListMonHoc().Count();
            ViewBag.ThongKe = new ThongKeDao().ListThongKe().Count();
            ViewBag.NamHoc = new NamHocDao().ListNamHoc().Count();
            return View();
        }
    }
}