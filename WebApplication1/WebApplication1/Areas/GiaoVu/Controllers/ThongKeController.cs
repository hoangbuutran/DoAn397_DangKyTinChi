using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Areas.GiaoVu.Models;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class ThongKeController : LoginChungController
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

        public ActionResult ExportToExcel(int namHoc, int hocKy)
        {
            GridView gv = new GridView();
            gv.DataSource = THONGKETONGTINCHITHEOMON(namHoc, hocKy);
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ThongKeExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            htw.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            ThongKeModel tk = new ThongKeModel
            {
                NamHoc = namHoc,
                HocKy = hocKy
            };
            return RedirectToAction("ThongKe", "ThongKe", new { thongke = tk });
        }

    }
}