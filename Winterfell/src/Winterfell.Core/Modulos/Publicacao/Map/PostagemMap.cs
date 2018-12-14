using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winterfell.Core.Modulos.Publicacao.Map
{
    public class PostagemMap : ClassMapping<Postagem>
    {
        public PostagemMap()
        {
            Table("Postagem");

            Id(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);               
            });

            Property(x => x.Usuario, m => m.Column("Usuario"));

            Property(x => x.Publicacao, m => m.Column("Publicacao"));

            Property(x => x.Titulo, m => m.Column("Titulo"));

            Property(x => x.Ativa, m => m.Column("Ativa"));

            Property(x => x.Imagem, m => m.Column("Imagem"));

            Property(x => x.ImagemMimeType, m => m.Column("ImagemType"));

            Property(x => x.Foto, m => m.Column("Foto"));

            Bag(
                x => x.Categoria,
                map =>
                {
                    map.Table("Categoria");
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
