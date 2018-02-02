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
                "SinhVienController",
                "GiaoVu/SinhVien/{action}/{id}",
                new { action = "Index", controller = "SinhVien", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "MonHocController",
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