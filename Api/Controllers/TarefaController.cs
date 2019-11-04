using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using Api.Configuration;
using Api.Interface;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private IUserService _userService;

        private ITarefaService _tarefaService;

        private readonly AplicacaoContext _context;

        public TarefaController(
        IUserService userService, 
        ITarefaService tarefaService, 
        AplicacaoContext context)
        {
            _userService = userService;
            _tarefaService = tarefaService;
            _context = context;
        }

        [HttpGet("Listar")]
        public IActionResult GetAll()
        {
            var tarefas =  _tarefaService.GetAll();
            return Ok(tarefas);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{tarefaId}")]
        public IActionResult GetById(int tarefaId)
        {
            var tarefa =  _tarefaService.GetById(tarefaId);
            return Ok(tarefa);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public IActionResult Create([FromBody] Tarefa tarefa)
        {
            this._tarefaService.Create(tarefa);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        public IActionResult Update([FromBody] Tarefa tarefa)
        {
            this._tarefaService.Update(tarefa);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        public IActionResult Delete(Tarefa tarefa)
        {
            this._tarefaService.Delete(tarefa);
            return Ok();
        }
    }
}
