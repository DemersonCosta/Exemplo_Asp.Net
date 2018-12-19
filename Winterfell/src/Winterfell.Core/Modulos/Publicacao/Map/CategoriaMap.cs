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

            Bag(
               x => x.Postagem,
               map =>
               {
                   map.Table("Postagem");
                   map.Fetch(CollectionFetchMode.Select);
                    //map.Lazy(CollectionLazy.Lazy);
                    map.Cascade(Cascade.All);
                    //map.Inverse(true);
                    map.Key(k => k.Column("IdPostagem"));

               },
               r => r.OneToMany()
           );
            
        }
        
    }
}
