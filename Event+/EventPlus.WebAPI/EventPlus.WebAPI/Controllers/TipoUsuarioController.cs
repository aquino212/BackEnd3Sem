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

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo listar os tipos de usuarios
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de usuario</returns>
    [HttpGet]
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

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo buscar um tipo de usuario especifico
    /// </summary>
    /// <param name="id">Id do tipo de evento buscado</param>
    /// <returns>Status code 200 e o tipo de usuario buscado</returns>
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

    /// <summary>
    /// Endpoit da API que faz a chamada para o método de cadastar um tipo de usuario 
    /// </summary>
    /// <param name="tipoUsuario"></param>
    /// <returns>Status code 201 e o tipo de usuario a ser cadastrado</returns>
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

    /// <summary>
    /// Endpoit da api que faz a chamada para o método de atualizar para um tipo de usuario
    /// </summary>
    /// <param name="id">Id do tipo usuario a ser atualizado</param>
    /// <param name="tipoEvento">Tipo usuario com os dados atualizados</param>
    /// <returns>Status code 204 e o tipo usuario atualizado</returns>
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

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de deletar um tipo de usuario
    /// </summary>
    /// <param name="id">Id do tipo usuario a ser excluído</param>
    /// <returns>Status code 204</returns>
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

