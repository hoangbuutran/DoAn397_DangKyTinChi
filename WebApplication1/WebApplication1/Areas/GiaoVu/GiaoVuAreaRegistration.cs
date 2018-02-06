using System.Web.Mvc;

namespace WebApplication1.Areas.GiaoVu
{
    public class GiaoVuAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GiaoVu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ThongTinChungGiaoVu",
                "GiaoVu/SinhVien/{action}/{id}",
                new { action = "Index", controller = "ThongTinChung", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "ThongKeGiaoVu",
                "GiaoVu/ThongKe/{action}/{id}",
                new { action = "Index", controller = "ThongKe", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "SinhVienGiaoVu",
                "GiaoVu/SinhVien/{action}/{id}",
                new { action = "Index", controller = "SinhVien", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "MonHocGiaoVu",
                "GiaoVu/MonHoc/{action}/{id}",
                new { action = "Index", controller = "MonHoc", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "GiaoVu_default",
                "GiaoVu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}