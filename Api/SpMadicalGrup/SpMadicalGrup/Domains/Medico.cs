using System;
using System.Collections.Generic;

#nullable disable

namespace SpMadicalGrup.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public short MedicoId { get; set; }
        public short? ClinicaId { get; set; }
        public int? UsuarioId { get; set; }
        public byte? TipoMedicoId { get; set; }
        public string Crm { get; set; }
        public string Nome { get; set; }

        public virtual Clinica Clinica { get; set; }
        public virtual TipoMedico TipoMedico { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
