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

            Property(x => x.DataPost, m => m.Column("DataPost"));

            Property(x => x.Titulo, m => m.Column("Titulo"));

            Property(x => x.Ativa, m => m.Column("Ativa"));

            Property(x => x.Imagem, m => m.Column("Imagem"));

            Property(x => x.ImagemMimeType, m => m.Column("ImagemType"));

            //Property(x => x.Foto, m => m.Column("Foto"));

            ManyToOne(
                c => c.Categoria, 
                map => map.Column("IdCategoria")
            
            );

        }
    }
}
