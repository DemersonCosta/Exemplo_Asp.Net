using System;
using System.Collections.Generic;
using Winterfell.Core.Domain.Model;
using Winterfell.Core.Modulos.EnderecoModulo;

namespace Winterfell.Core.Modulos.UsuarioModulo
{
    public class Usuario: IIdentifiable
    {       
        public virtual long Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Email { get; set; }

        public virtual string Telefone { get; set; }

        public virtual string CPF { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }        

        public virtual DateTime DataCadastro { get; set; }        

        public virtual IList<Endereco> Endereco { get; set; }
    }
}
