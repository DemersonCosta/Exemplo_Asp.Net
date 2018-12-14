using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winterfell.Core.Modulos.EnderecoModulo;

namespace Winterfell.Core.Modulos.UsuarioModulo.Map
{
    public class UsuarioMap: ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property(x => x.Nome, c => c.Column("Nome"));

            Property(x => x.CPF, c => c.Column("CPF"));

            Property(x => x.Email, c => c.Column("Email"));

            Property(x => x.Telefone, c => c.Column("Telefone"));

            Property(x => x.Login, c => c.Column("Login"));

            Property(x => x.Senha, c => c.Column("Senha"));

            Property(x => x.DataCadastro, c => c.Column("DataCadastro"));            
            
            ManyToOne(x => x.Endereco, m =>
            {
                m.Cascade(Cascade.All);
                m.Column("IdEndereco");
            });
            

        }
    }
}
