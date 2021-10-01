using System;
using System.Collections.Generic;

#nullable disable

namespace SpMadicalGrup.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int UsuarioId { get; set; }
        public byte? TipoUsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
