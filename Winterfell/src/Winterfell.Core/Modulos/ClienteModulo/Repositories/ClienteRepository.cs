using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using Winterfell.Core.Domain.Repositories;

namespace Winterfell.Core.Modulos.ClienteModulo.Repositories
{
    public interface IClienteRepository: ICrudRepository<Cliente, long>
    {
        IList<Cliente> Find(string nome, string email);
    }

    public class ClienteRepository : DefaultRepository<Cliente, long>, IClienteRepository
    {
        public ClienteRepository(ISession session) : base(session)
        {

        }

        public IList<Cliente> Find(string nome, string email)
        {
            var query = Session.QueryOver<Cliente>();

            if (!string.IsNullOrEmpty(nome))
                query.WhereRestrictionOn(x => x.Nome).IsLike(nome, MatchMode.Anywhere);

            if (!string.IsNullOrEmpty(email))
                query.WhereRestrictionOn(x => x.Email).IsLike(email, MatchMode.Anywhere);

            return query.List();
        }
    }
}

