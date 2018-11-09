using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winterfell.Core.Modulos.UsuarioModulo.Repositories;
using Winterfell.Web.Infra.Controllers;

namespace Winterfell.Web.Areas.Admin.Controllers
{
    public class AdministrativoController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AdministrativoController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        // GET: Admin/Administrativo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetViewData()
        {
            var list = _usuarioRepository.FindAll();

            return Json(list);
        }
    }
}