using SpMadicalGrup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();
    }
}
