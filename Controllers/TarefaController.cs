using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Models.DTOs;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        private (Tarefa, bool) FindTask(int id)
        {
            var task = _context.Tarefas.Find(id);
            if (task == null)
                return (null, false);
        
            return (task, true);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var (task, found) = FindTask(id);

            if (!found)
                return NotFound();

            return Ok(task);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tasks = _context.Tarefas.ToList();
            return Ok(tasks);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var task = _context.Tarefas.Where(x => x.Titulo == titulo);
            return Ok(task);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefa = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Criar(TaskDTO task)
        {
            var tarefa = new Tarefa(task.Titulo, task.Descricao, task.Status);

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var (task, found) = FindTask(id);

            if (task == null)
                return NotFound();

            _context.Tarefas.Remove(task);
            return NoContent();
        }
    }
}
