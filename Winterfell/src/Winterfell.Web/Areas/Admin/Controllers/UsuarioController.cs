using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winterfell.Core.Modulos.UsuarioModulo;
using Winterfell.Core.Modulos.UsuarioModulo.Repositories;
using Winterfell.Web.Infra.Controllers;

namespace Winterfell.Web.Areas.Admin.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        // GET: Admin/Usuario

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

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