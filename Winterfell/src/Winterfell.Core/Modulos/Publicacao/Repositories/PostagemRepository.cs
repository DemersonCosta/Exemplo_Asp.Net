using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winterfell.Core.Domain.Repositories;

namespace Winterfell.Core.Modulos.Publicacao.Repositories
{
    public interface IPostagemRepository : ICrudRepository<Postagem, long>
    {

    }
    public class PostagemRepository : DefaultRepository<Postagem, long>, IPostagemRepository 
    {
        public PostagemRepository(ISession session) : base(session)
        {

        }

    }
}
