using SpMadicalGrup.Contexts;
using SpMadicalGrup.Domains;
using SpMadicalGrup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMadicalContext ctx = new SpMadicalContext();
        public void Atualizar(int Id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(Id);

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscaPorId(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.UsuarioId == Id);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Usuario UsuarioDeletado = BuscaPorId(Id);
            ctx.Usuarios.Remove(UsuarioDeletado);
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }
    }
}
