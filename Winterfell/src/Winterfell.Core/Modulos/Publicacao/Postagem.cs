using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Winterfell.Core.Domain.Model;

namespace Winterfell.Core.Modulos.Publicacao
{
    public class Postagem : IIdentifiable
    {

        public virtual long Id { get; set; }       

        public virtual DateTime DataPost { get; set; }

        public virtual string Titulo { get; set; }

        public virtual string Texto { get; set; }

        public virtual bool Ativa { get; set; }

        [ScriptIgnore]
        public virtual byte[] Imagem { get; set; }

        [ScriptIgnore]
        public virtual string Foto
        {
            get
            {
                return (Imagem == null ? string.Empty : Convert.ToBase64String(Imagem));
            }
            set
            {
                this.Foto = value;
            }
        }

        public virtual string ImagemMimeType { get; set; }

        public virtual Categoria Categoria { get; set; }


    }
}
