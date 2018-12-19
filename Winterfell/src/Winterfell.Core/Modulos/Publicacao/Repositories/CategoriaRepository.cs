using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winterfell.Core.Domain.Repositories;

namespace Winterfell.Core.Modulos.Publicacao.Repositories
{
    public interface ICategoria : ICrudRepository<Categoria, long>
    {

    }

    public class CategoriaRepository : DefaultRepository<Categoria, long>,ICategoria
    {
        public CategoriaRepository( ISession session) : base(session)
        {

        }
    }
}
