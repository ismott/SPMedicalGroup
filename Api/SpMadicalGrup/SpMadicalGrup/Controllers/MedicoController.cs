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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicoController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        [HttpPost]
        public IActionResult Post(Medico NovaConsulta)
        {
            try
            {
                _MedicoRepository.Cadastrar(NovaConsulta);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Medico> ListarTodos = _MedicoRepository.ListarTodos();

                return Ok(ListarTodos);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
