using NHibernate;
using Winterfell.Core.Domain.Repositories;

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
