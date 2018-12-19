using System.Collections.Generic;
using Winterfell.Core.Domain.Model;

namespace Winterfell.Core.Modulos.Publicacao
{
    public class Categoria : IIdentifiable
    {
        public virtual long Id { get; set; }

        public virtual string NomeCategoria { get; set; }      

        public virtual IList<Postagem> Postagem { get; set; }
    }
}
