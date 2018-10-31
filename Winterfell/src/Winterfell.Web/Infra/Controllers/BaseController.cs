using System.Net;
using System.Web.Mvc;
using Winterfell.Core.Domain.Controller;

namespace Winterfell.Web.Infra.Controllers
{
    public class BaseController : Controller, IWinterfellController
    {
        /// <summary>
        /// IP do usuário.
        /// </summary>
        public string IP => Request.ServerVariables["REMOTE_ADDR"];

        protected JsonResult JsonError(string msg)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return Json(new { message = msg }, "text/html");
        }
    }
}