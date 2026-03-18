using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private IPresencaRepository _PresencaRepository;
    public PresencaController(IPresencaRepository presencaRepository)
    {
            _PresencaRepository = presencaRepository;
    }

    /// <summary>
    ///Endpoint da API que retorna listar a presenças de um usuario expecifico
    /// </summary>
    /// <param name="idUsuario">id do usuário para filtragem</param>
    /// <returns>Status Code 200 e uma Lista de presenças</returns>
    [HttpGet("ListarMinhas/{idUsuario}")]
    public IActionResult BuscarMinhas(Guid idUsuario)
    {
        try
        {
            return Ok(_PresencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {
        try
        {
            var novaPresenca = new Presenca
            {
                Situacao = presenca.Situacao,
                Idevento = presenca.IdEvento,
                Idusuario = presenca.IdUsuario,
            };
            _PresencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpPut]
    public IActionResult Atualizar(Guid id, Presenca presenca)
    {
        try
        {
            _PresencaRepository.Atualizar(id, presenca);
            return Ok(presenca);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpDelete]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _PresencaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




}
