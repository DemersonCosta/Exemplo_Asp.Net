using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winterfell.Core.Modulos.Publicacao.Repositories;
using Winterfell.Web.Infra.Controllers;

namespace Winterfell.Web.Areas.Admin.Controllers
{
    public class PostagemController : BaseController
    {

        private readonly IPostagemRepository _postagemRepository;

        public PostagemController(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetViewData()
        {
            var list = _postagemRepository.FindAll();

            return Json(list);
        }
    }
}