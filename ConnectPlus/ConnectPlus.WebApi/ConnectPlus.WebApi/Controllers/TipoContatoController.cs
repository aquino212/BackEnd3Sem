using ConnectPlus.WebApi.Interfaces;
using ConnectPlus.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoContatoController : ControllerBase
{
    private readonly ITipoContatoRepository _tipoContatoRepository;
    public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
    {
        _tipoContatoRepository = tipoContatoRepository;
    }
    [HttpGet]
    public IActionResult Listar()
    {
        var tipoContatos = _tipoContatoRepository.Listar();
        return Ok(tipoContatos);
    }
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var tipoContato = _tipoContatoRepository.BuscarPoId(id);
        if (tipoContato == null)
            return NotFound();
        return Ok(tipoContato);
    }
    [HttpPost]
    public IActionResult Adicionar(TipoContato tipoContato)
    {
        _tipoContatoRepository.Adicionar(tipoContato);
        return CreatedAtAction(nameof(BuscarPorId), new { id = tipoContato.IdTipoContato }, tipoContato);
    }
    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, TipoContato tipoContato)
    {
        var tipoContatoExistente = _tipoContatoRepository.BuscarPoId(id);
        if (tipoContatoExistente == null)
            return NotFound();
        _tipoContatoRepository.Atualizar(tipoContato);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var tipoContatoExistente = _tipoContatoRepository.BuscarPoId(id);
        if (tipoContatoExistente == null)
            return NotFound();
        _tipoContatoRepository.Deletar(id);
        return NoContent();
    }

}
