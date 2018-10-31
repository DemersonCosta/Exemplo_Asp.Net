using System;
using System.CodeDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Winterfell.Core;
using Winterfell.Core.Modulos.ClienteModulo;
using Winterfell.Core.Modulos.ClienteModulo.Repositories;

namespace Winterfell.Tests.Core.ClienteModulo
{
    [TestClass]
    public class ClienteRepositoryTestCase: BaseRepositoryTestCase
    {
        [TestMethod]
        public void Should_Add_Cliente()
        {
            var cliente = new Cliente
            {
                Nome = "Ricardo",
                CPF = "11111111111",
                Email = "ricardo@teste.mp.br",
                Nascimento = DateTime.Now
            };

            var target = Container.Resolve<IClienteRepository>();

            target.Add(cliente);

            Assert.IsTrue(cliente.Id > 0);
        }

        [TestMethod]
        public void Should_Add_And_Remove_Cliente()
        {
            var cliente = new Cliente
            {
                Nome = "Ricardo",
                CPF = "11111111111",
                Email = "ricardo@teste.mp.br",
                Nascimento = DateTime.Now
            };

            var clienteRepository = Container.Resolve<IClienteRepository>();

            clienteRepository.Add(cliente);

            Assert.IsTrue(cliente.Id > 0);

            clienteRepository.Remove(cliente);

            var list = clienteRepository.FindAll();

            Assert.AreEqual(0, list.Count);
        }
    }
}