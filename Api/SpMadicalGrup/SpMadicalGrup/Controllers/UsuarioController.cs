using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMadicalGrup.Domains;
using SpMadicalGrup.Interfaces;
using SpMadicalGrup.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMadicalGrup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "1")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Usuario NovaUsuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(NovaUsuario);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult GetAll()
        {
            try
            {
                List<Usuario> ListarTodos = _UsuarioRepository.ListarTodos();

                return Ok(ListarTodos);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _UsuarioRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_UsuarioRepository.BuscaPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _UsuarioRepository.Atualizar(id, UsuarioAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
