using SpMadicalGrup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();
        void Cadastrar(Paciente NovoPaciente);
    }
}
