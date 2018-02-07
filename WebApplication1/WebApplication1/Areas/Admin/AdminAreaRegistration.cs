using System.Web.Mvc;

namespace WebApplication1.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TaiKhoanAdmin",
                "Admin/TaiKhoan/{action}/{id}",
                new { action = "Index", controller = "TaiKhoan", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "LoaiNguoiDungAdmin",
                "Admin/LoaiNguoiDung/{action}/{id}",
                new { action = "Index", controller = "LoaiNguoiDung", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional }
            );
        }
    }
}