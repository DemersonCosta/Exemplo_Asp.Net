using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System.Collections.Generic;
using Winterfell.Core.Domain.Repositories;
using Winterfell.Core.Modulos.EnderecoModulo;

namespace Winterfell.Core.Modulos.UsuarioModulo.Repositories
{
    public interface IUsuarioRepository : ICrudRepository<Usuario, long>
    {
        
    }
    public class UsuarioRepository : DefaultRepository<Usuario, long>, IUsuarioRepository
    {
        public UsuarioRepository(ISession session) : base (session)
        {

        }

        
    }
}
