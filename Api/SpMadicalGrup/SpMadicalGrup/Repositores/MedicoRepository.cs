using SpMadicalGrup.Contexts;
using SpMadicalGrup.Domains;
using SpMadicalGrup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Repositores
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMadicalContext ctx = new SpMadicalContext();

        public void Cadastrar(Medico NovoMedico)
        {
            ctx.Medicos.Add(NovoMedico);
            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}
