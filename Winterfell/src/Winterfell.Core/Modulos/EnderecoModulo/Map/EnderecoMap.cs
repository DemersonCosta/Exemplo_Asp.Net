using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Winterfell.Core.Modulos.EnderecoModulo.Map
{
    public class EnderecoMap: ClassMapping<Endereco>
    {
        public EnderecoMap()
        {
            Table("Endereco");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
                m.Column("IdEndereco");
            });

            Property(x => x.Cidade, c => c.Column("Cidade"));

            Property(x => x.Rua, c => c.Column("Rua"));

            Property(x => x.Num, c => c.Column("Num"));

            Property(x => x.Bairro, c => c.Column("Bairro"));

            Property(x => x.Cep, c => c.Column("Cep"));

            Property(x => x.Complemento, c => c.Column("Complemento"));


            ManyToOne(x => x.Usuario, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column("IdUsuario");
            });


        }
    }
}
