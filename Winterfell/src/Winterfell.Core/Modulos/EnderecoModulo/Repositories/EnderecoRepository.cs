using NHibernate;
using Winterfell.Core.Domain.Repositories;

namespace Winterfell.Core.Modulos.EnderecoModulo.Repositories
{
    public interface IEnderecoRepository : ICrudRepository<Endereco, long>
    {
        
    }

    public class EnderecoRepository : DefaultRepository<Endereco, long>, IEnderecoRepository
    {
        public EnderecoRepository(ISession session) : base(session)
        {

        }

    }
}
