using System;
using System.Collections.Generic;

#nullable disable

namespace SpMadicalGrup.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public byte SituacaoId { get; set; }
        public string NomeSituacao { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
