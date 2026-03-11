using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstutuicaoController : ControllerBase
{
    private IInstituicaoRepository _InstituicaoRepository;
    public InstutuicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _InstituicaoRepository = instituicaoRepository;
    }
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_InstituicaoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpGet("{id}")]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_InstituicaoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpPost("{id}")]
    public IActionResult Cadastrar(Models.Instituicao instituicao)
    {
        try
        {
            _InstituicaoRepository.Cadastrar(instituicao);
            return Created("Objeto criado", instituicao);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, Instituicao instituicao)
    {
        try
        {
            _InstituicaoRepository.Atualizar(id, instituicao);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }

    }
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _InstituicaoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
