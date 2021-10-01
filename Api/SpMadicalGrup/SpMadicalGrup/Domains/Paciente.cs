using System;
using System.Collections.Generic;

#nullable disable

namespace SpMadicalGrup.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int PacienteId { get; set; }
        public int? UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNacimento { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
