using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Winterfell.Core.Modulos.Publicacao;
using Winterfell.Core.Modulos.Publicacao.Repositories;
using Winterfell.Web.Infra.Controllers;

namespace Winterfell.Web.Areas.Admin.Controllers
{
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        // GET: Admin/Categoria

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetViewData()
        {
            var list = _categoriaRepository.FindAll();

            return Json(list);
        }

        public JsonResult Salvar(Categoria categoria)
        {
            try
            {
               
                _categoriaRepository.AddOrUpdate(categoria);

                return Json(categoria);
            }

            catch (Exception e)
            {
                return RetrieveError("Serviço indisponível." + e);
            }
        }

        public JsonResult Excluir(Categoria categoria)
        {
            try
            {

                _categoriaRepository.Remove(categoria.Id);

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