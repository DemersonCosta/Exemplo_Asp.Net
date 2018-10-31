using System;
using Winterfell.Core.Domain.Model;

namespace Winterfell.Core.Modulos.ClienteModulo
{
    public class Cliente: IIdentifiable
    {
        public virtual long Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Email { get; set; }

        public virtual string CPF { get; set; }

        public virtual DateTime Nascimento { get; set; }
    }
}

