using SpMadicalGrup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuario NovoUsuario);

        void Deletar(int Id);

        List<Usuario> ListarTodos();

        Usuario BuscaPorId(int Id);

        void Atualizar(int Id, Usuario UsuarioAtualizado);

        Usuario Login(string Email, string Senha);
    }
}
