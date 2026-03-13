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

    /// <summary>
    /// Endpoit da API que faz a chamada para o método de cadastar uma instituicao 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status code 201 e a instituicao a ser cadastrado</returns>
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

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo listar os tipos de eventos
    /// </summary>
    /// <returns>Status code 200 e a lista de instituicao</returns>
    [HttpGet]
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

    /// <summary>
    /// Endpoit da API que faz a chamada para o método de cadastar uma instituicao
    /// </summary>
    /// <param name="instituicao"></param>
    /// <returns>Status code 201 e a instituicao a ser cadastrado</returns>
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

    /// <summary>
    /// Endpoit da api que faz a chamada para o método de atualizar para uma instituicao
    /// </summary>
    /// <param name="id">Id da instituicao a ser atualizado</param>
    /// <param name="tipoEvento">Instituicao com os dados atualizados</param>
    /// <returns>Status code 204 e a instituicao atualizado</returns>
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

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de deletar uma instituicao
    /// </summary>
    /// <param name="id">Id da instituicao a ser excluído</param>
    /// <returns>Status code 204</returns>
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
