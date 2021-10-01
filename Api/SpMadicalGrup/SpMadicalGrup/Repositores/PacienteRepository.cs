using SpMadicalGrup.Contexts;
using SpMadicalGrup.Domains;
using SpMadicalGrup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Repositores
{
    public class PacienteRepository : IPacienteRepository
    {
        SpMadicalContext ctx = new SpMadicalContext();

        public void Cadastrar(Paciente NovoPaciente)
        {
            ctx.Pacientes.Add(NovoPaciente);
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
