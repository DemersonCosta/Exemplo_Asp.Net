using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winterfell.Core.Modulos.Publicacao.Map
{
    public class CategoriaMap : ClassMapping<Categoria>
    {
        public CategoriaMap()
        {
            Table("Categoria");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);              
            });

            Property(x => x.NomeCategoria, m => m.Column("NomeCategoria"));

            ManyToOne(x => x.Postagem, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column("IdPostagem");
            });

        }
        
    }
}
