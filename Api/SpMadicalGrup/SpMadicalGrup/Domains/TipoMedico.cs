using System;
using System.Collections.Generic;

#nullable disable

namespace SpMadicalGrup.Domains
{
    public partial class TipoMedico
    {
        public TipoMedico()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte TipoMedicoId { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
