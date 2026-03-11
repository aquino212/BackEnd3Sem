using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepository _TipoUsuarioRepository;
    public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _TipoUsuarioRepository = tipoUsuarioRepository;
    }
    [HttpGet("{id}")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_TipoUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
    }
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_TipoUsuarioRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpPost("{id}")]
    public IActionResult Cadastrar(TipoUsuario tipoUsuario)
    {
        try
        {
            _TipoUsuarioRepository.Cadastrar(tipoUsuario);
            return StatusCode(201);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        try
        {
            _TipoUsuarioRepository.Atualizar(id, tipoUsuario);
            return StatusCode(204);
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
            _TipoUsuarioRepository.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




}

