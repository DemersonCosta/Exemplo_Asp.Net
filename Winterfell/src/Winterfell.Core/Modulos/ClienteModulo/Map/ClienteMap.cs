using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Winterfell.Core.Modulos.ClienteModulo.Map
{
    public class ClienteMap: ClassMapping<Cliente>
    {
        public ClienteMap()
        {
            Table("tCliente");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
                m.Column("IdCliente");
            });

            Property(x => x.Nome, c => c.Column("NmCliente"));

            Property(x => x.CPF, c => c.Column("NuCPF"));

            Property(x => x.Email, c => c.Column("DsEmail"));

            Property(x => x.Nascimento, c => c.Column("DtNascimento"));
        }
    }
}
