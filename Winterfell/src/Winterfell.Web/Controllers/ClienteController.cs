
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Winterfell.Core.Modulos.ClienteModulo;
using Winterfell.Core.Modulos.ClienteModulo.Repositories;
using Winterfell.Web.Infra.Controllers;

namespace Winterfell.Web.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Pesquisar(string nome, string email)
        {
            var result = GetDadosClientes(nome, email);

            return View("Consulta", result.ToList());
        } 
        

        public IList<Cliente> GetDadosClientes(string nome, string email)
        {
            return _clienteRepository.Find(nome, email);
        }

        public JsonResult GetViewData()
        {
            var list = _clienteRepository.FindAll();

            return Json(list);
        }

        public JsonResult Salvar(Cliente cliente)
        {
            try {

                _clienteRepository.AddOrUpdate(cliente);

                return Json(cliente);
            }

            catch (Exception )
            {
                return RetrieveError("Serviço indisponível.");
            }
        }

        public JsonResult Excluir(Cliente cliente)
        {
            try {

                _clienteRepository.Remove(cliente.Id);

                return Json(new {});
            }

            catch (Exception )
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
