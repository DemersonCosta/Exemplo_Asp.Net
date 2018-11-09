using System.Web.Mvc;

namespace Winterfell.Web.Areas.Admin
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
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {Controller = "Administrativo", action = "Index", id = UrlParameter.Optional },
                new []{ "Winterfell.Web.Areas.Admin.Controllers" }
            );
        }
    }
}