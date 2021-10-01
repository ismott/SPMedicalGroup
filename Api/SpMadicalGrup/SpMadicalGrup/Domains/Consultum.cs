using System;
using System.Collections.Generic;

#nullable disable

namespace SpMadicalGrup.Domains
{
    public partial class Consultum
    {
        public long ConsultaId { get; set; }
        public short? MedicoId { get; set; }
        public byte SituacaoId { get; set; }
        public int? PacienteId { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Situacao Situacao { get; set; }
    }
}
