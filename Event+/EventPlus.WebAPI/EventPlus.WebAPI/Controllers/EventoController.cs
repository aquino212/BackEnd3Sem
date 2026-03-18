using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private IEventoRepository _EventoRepository;
    public EventoController(IEventoRepository eventoRepository)
    {
        _EventoRepository = eventoRepository;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo listar  eventos filtrado por usuario
    ///</summary>
    ///<param name="idUsuario">Id do usuário para filtragem</param>
    ///<returns>Status code 200 e a lista de tipos de evento</returns>
    [HttpGet("Usuario/{idUsuario}")]
    public IActionResult ListarPorId(Guid idUsuario)
    {
        try
        {
            return Ok(_EventoRepository.ListarPorId(idUsuario));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo listar proximo eventos
    /// </summary>
    /// <returns>Status Code 200 e uma lista de proximos eventos</returns>
    [HttpGet("ListarProximos")]
    public IActionResult BuscarProximos()
    {
        try
        {
            return Ok(_EventoRepository.ListarProximo());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Cadastra um novo evento no banco de dados, utilizando os dados fornecidos no corpo da requisição.
    /// </summary>
    /// <param name="evento"></param>
    /// <returns>Status code 201 e o evento a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(Evento evento)
    {
        try
        {
            _EventoRepository.Cadastrar(evento);
            return StatusCode(201, evento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    ///Endpoint da API que faz a chamada para o metodo atualizar evento, utilizando os dados fornecidos no corpo da requisição.
    /// </summary>
    /// <param name="evento">Instituicao com os dados atualizados</param>
    /// <returns>Status code 204 e o evento atualizado</returns>
    [HttpPut]
    public IActionResult Atualizar(Evento evento)
    {
        try
        {
            _EventoRepository.Atualizar(evento);
            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    ///Endpoint da API que faz a chamada para o metodo deletar evento, utilizando o id do evento fornecido na URL da requisição.
    /// </summary>
    /// <param name="id">Id do Evento a ser excluído</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _EventoRepository.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_EventoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
