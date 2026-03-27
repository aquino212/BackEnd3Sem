using ConnectPlus.WebApi.Interfaces;
using ConnectPlus.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
        private readonly IContatoRepository _contatoRepository;
    
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
    
        [HttpGet]
        public IActionResult Listar()
        {
            var contatos = _contatoRepository.Listar();
            return Ok(contatos);
        }
    
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            var contato = _contatoRepository.BuscarPoId(id);
            if (contato == null)
                return NotFound();
    
            return Ok(contato);
        }
    
        [HttpPost]
        public IActionResult Adicionar(Contato contato)
        {
            _contatoRepository.Adicionar(contato);
            return CreatedAtAction(nameof(BuscarPorId), new { id = contato.IdContato }, contato);
        }
    
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, Contato contato)
        {
    
            var contatoExistente = _contatoRepository.BuscarPoId( id);
            if (contatoExistente == null)
                return NotFound();
    
            _contatoRepository.Atualizar(id, contato);
            return NoContent();
        }
    
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            var contatoExistente = _contatoRepository.BuscarPoId(id);
            if (contatoExistente == null)
                return NotFound();
    
            _contatoRepository.Deletar(id);
            return NoContent();
    }
}
