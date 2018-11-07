using Winterfell.Core.Domain.Model;
using Winterfell.Core.Modulos.UsuarioModulo;

namespace Winterfell.Core.Modulos.EnderecoModulo
{
    public class Endereco : IIdentifiable
    {
        public virtual long Id { get; set; }

        public virtual string Cidade { get; set; }

        public virtual string Rua { get; set; }

        public virtual string Num { get; set; }

        public virtual string Bairro { get; set; }

        public virtual string Cep { get; set; }

        public virtual string Complemento { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
