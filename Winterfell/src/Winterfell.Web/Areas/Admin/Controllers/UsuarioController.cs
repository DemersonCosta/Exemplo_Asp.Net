using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public JsonResult Salvar(Usuario usuario)
        {
            try
            {
                if (usuario.Id <= 0 && usuario.DataCadastro != DateTime.Now)
                {
                    usuario.DataCadastro = DateTime.Now;
                }
                _usuarioRepository.AddOrUpdate(usuario);

                return Json(usuario);
            }

            catch (Exception e)
            {
                return RetrieveError("Serviço indisponível." + e);
            }
        }

        public JsonResult Excluir(Usuario usuario)
        {
            try
            {

                _usuarioRepository.Remove(usuario.Id);

                return Json(new { });
            }

            catch (Exception)
            {
                return RetrieveError("Serviço indisponível.");
            }
        }

        protected JsonResult RetrieveError(string msg)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return Json(new { message = msg }, "text/html");
        }
    }
}