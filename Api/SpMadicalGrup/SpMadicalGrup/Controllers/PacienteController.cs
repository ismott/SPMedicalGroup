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
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _PacienteRepository { get; set; }

        public PacienteController()
        {
            _PacienteRepository = new PacienteRepository();
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Paciente NovaConsulta)
        {
            try
            {
                _PacienteRepository.Cadastrar(NovaConsulta);

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
                List<Paciente> ListarTodos = _PacienteRepository.ListarTodos();

                return Ok(ListarTodos);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
