using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.GiaoVu.Models;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class ThongKeController : Controller
    {

        public ActionResult Index()
        {
            PhieuDangKyDao dao = new PhieuDangKyDao();
            ViewBag.DSNamHoc = new SelectList(dao.ListNamHoc(), "ID_NAM_HOC", "TEN_NAM_HOC");
            ViewBag.DSHocKy = new SelectList(dao.ListHocKy(), "ID_HOC_KY", "TEN_HOC_KY");
            return View();
        }

        public List<KetQuaThongKe> THONGKETONGTINCHITHEOMON(int namhoc, int hocky)
        {
            CoSoDuLieuDbContext db = new CoSoDuLieuDbContext();
            object[] parameter =
            {
                new SqlParameter("@ID_NAM_HOC", namhoc),
                new SqlParameter("@ID_HOC_KY", hocky),
            };
            return db.Database.SqlQuery<KetQuaThongKe>("TONGTINCHICODUOC @ID_NAM_HOC, @ID_HOC_KY", parameter).ToList();
        }

        [HttpPost]
        public ActionResult ThongKe(ThongKeModel thongke)
        {
            ViewBag.thongkedao = THONGKETONGTINCHITHEOMON(thongke.NamHoc, thongke.HocKy);
            ViewBag.ThongTinNam = new ThongTinChungDao().NamHocSinger(thongke.NamHoc);
            ViewBag.ThongTinHocKy = new ThongTinChungDao().HocKySinger(thongke.HocKy);
            return View();
        }
    }
}