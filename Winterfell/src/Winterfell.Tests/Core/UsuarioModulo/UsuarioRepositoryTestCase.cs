using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Winterfell.Core.Modulos.UsuarioModulo;
using Winterfell.Core.Modulos.EnderecoModulo;
using Winterfell.Core.Modulos.UsuarioModulo.Repositories;
using System.Collections.Generic;

namespace Winterfell.Tests.Core.UsuarioModulo
{

    [TestClass]
    public class UsuarioRepositoryTestCase : BaseRepositoryTestCase
    {

        [TestMethod]
        public void should_Add_Usuario()
        {                       
            
            var usuario2 = new Usuario
            {
                Nome = "Alan",
                CPF = "11111111111",
                Email = "Demerson@teste.mp.br",
                Telefone = "51515155",
                DataCadastro = DateTime.Now,
                Login = "Dcosta",
                Senha = "123456",
                Endereco = new List<Endereco>() { new Endereco() {
                    Cep = "teste",
                    Cidade = "atyfsya",
                    Bairro = "audgbausd",
                    Complemento = "sdoid",
                    Num = "msind",
                    Rua = "sdmid"
                    }
                }

            };

            var target = Container.Resolve<IUsuarioRepository>();

            target.AddOrUpdate(usuario2);

            Assert.IsTrue(usuario2.Id > 0);
        }
    }
}
