using SpMadicalGrup.Contexts;
using SpMadicalGrup.Domains;
using SpMadicalGrup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Repositores
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMadicalContext ctx = new SpMadicalContext();

        public void AprovarRecusar(int IdPresenca, string Status)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int Id, Consultum ConsultumAtualizado)
        {
            Consultum ConsultaBuscado = ctx.Consulta.Find(Id);

            if (ConsultumAtualizado.MedicoId != null || ConsultumAtualizado.PacienteId != null || ConsultumAtualizado.Descricao != null)
            {
                ConsultaBuscado.MedicoId = ConsultumAtualizado.MedicoId;
                ConsultaBuscado.PacienteId = ConsultumAtualizado.PacienteId;
                ConsultaBuscado.Descricao = ConsultumAtualizado.Descricao;

                ctx.Consulta.Update(ConsultaBuscado);
                ctx.SaveChanges();
            }
        }

        public Consultum BuscaPorId(int Id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.ConsultaId == Id);
        }

        public void Cadastrar(Consultum NovoConsultum)
        {
            ctx.Consulta.Add(NovoConsultum);
            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Consultum ConsultaDeletada = BuscaPorId(Id);

            ctx.Consulta.Remove(ConsultaDeletada);
        }

        public List<Consultum> ListarMinhas(int IdUsuario)
        {
            return ctx.Consulta.Where(c => c.SituacaoId == IdUsuario).ToList();
        }

        public List<Consultum> ListarTodos()
        {
            return ctx.Consulta.ToList();
        }
    }
}
