using Microsoft.EntityFrameworkCore;
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

        public void AprovarRecusar(int IdConsulta, string Status)
        {
            Consultum ConsultaBuscada = ctx.Consulta.FirstOrDefault(c => c.ConsultaId == IdConsulta);

            switch (Status)
            {
                case "1":
                    ConsultaBuscada.SituacaoId = 1;
                    break;
                case "2":
                    ConsultaBuscada.SituacaoId = 2;
                    break;
                case "3":
                    ConsultaBuscada.SituacaoId = 3;
                    break;
                default:
                    ConsultaBuscada.SituacaoId = ConsultaBuscada.SituacaoId;
                    break;
            }

            ctx.Consulta.Update(ConsultaBuscada);
            ctx.SaveChanges();
        }

        public void Atualizar(int Id, Consultum ConsultumAtualizado)
        {
            Consultum ConsultaBuscado = BuscaPorId(Id);

            if (ConsultaBuscado.Descricao != null)
            {
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
            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int IdUsuario)
        {
            Paciente PacienteBuscado = ctx.Pacientes.FirstOrDefault(x => x.UsuarioId == IdUsuario);

            Medico MedicoBuscado = ctx.Medicos.FirstOrDefault(x => x.UsuarioId == IdUsuario);

            if (PacienteBuscado != null)
            {
                return ctx.Consulta.Where(c => c.PacienteId == PacienteBuscado.PacienteId)
                               .Include(x => x.Paciente)
                               .Include(x => x.Medico)
                               .Include(x => x.Situacao)
                               .Select(x => new Consultum()
                               {
                                   ConsultaId = x.ConsultaId,
                                   Descricao = x.Descricao,
                                   DataConsulta = x.DataConsulta,
                                   Medico = new Medico()
                                   {
                                       Nome = x.Medico.Nome,
                                       Crm = x.Medico.Crm
                                   },
                                   Paciente = new Paciente()
                                   {
                                       Nome = x.Paciente.Nome,
                                       DataNacimento = x.Paciente.DataNacimento,
                                       Rg = x.Paciente.Rg
                                   },
                                   Situacao = new Situacao()
                                   {
                                       NomeSituacao = x.Situacao.NomeSituacao
                                   }
                               })
                               .ToList(); ;
            }
            if (MedicoBuscado != null)
            {
                return ctx.Consulta.Where(c => c.MedicoId == MedicoBuscado.MedicoId)
                               .Include(x => x.Paciente)
                               .Include(x => x.Medico)
                               .Include(x => x.Situacao)
                               .Select(x => new Consultum()
                               {
                                   ConsultaId = x.ConsultaId,
                                   Descricao = x.Descricao,
                                   DataConsulta = x.DataConsulta,
                                   Medico = new Medico()
                                   {
                                       Nome = x.Medico.Nome,
                                       Crm = x.Medico.Crm
                                   },
                                   Paciente = new Paciente()
                                   {
                                       Nome = x.Paciente.Nome,
                                       DataNacimento = x.Paciente.DataNacimento,
                                       Rg = x.Paciente.Rg
                                   },
                                   Situacao = new Situacao()
                                   {
                                       NomeSituacao = x.Situacao.NomeSituacao
                                   }
                               })
                               .ToList(); ;
            }

            return null;
        }

        public List<Consultum> ListarTodos()
        {
            return ctx.Consulta
                               .Include(x => x.Paciente)
                               .Include(x => x.Medico)
                               .Include(x => x.Situacao)
                               .Select(x => new Consultum ()
                               { 
                                    ConsultaId = x.ConsultaId,
                                    Medico = new Medico() 
                                    { 
                                        Nome = x.Medico.Nome,
                                        Crm = x.Medico.Crm
                                    },
                                    Paciente = new Paciente()
                                    {
                                        Nome = x.Paciente.Nome,
                                        DataNacimento = x.Paciente.DataNacimento,
                                        Rg = x.Paciente.Rg
                                    },
                                    Situacao = new Situacao()
                                    { 
                                        NomeSituacao = x.Situacao.NomeSituacao
                                    },
                                    Descricao = x.Descricao,
                                    DataConsulta = x.DataConsulta
                               })
                               .ToList();
        }
    }
}
