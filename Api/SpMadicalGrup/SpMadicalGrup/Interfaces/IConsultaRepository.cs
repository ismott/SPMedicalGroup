using SpMadicalGrup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Interfaces
{
    interface IConsultaRepository
    {
        void Cadastrar(Consultum NovoConsultum);

        void Deletar(int Id);

        List<Consultum> ListarTodos();

        Consultum BuscaPorId(int Id);

        void Atualizar(int Id, Consultum ConsultumAtualizado);

        List<Consultum> ListarMinhas(int IdUsuario);

        void AprovarRecusar(int IdPresenca, string Status);
    }
}
