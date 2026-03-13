using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private IUsuarioRepository _UsuarioRepository;
    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _UsuarioRepository = usuarioRepository;
    }

    /// <summary>
    /// Endpoint da Api que faz a chamada para o metódo de buscar um usuario por Id
    /// </summary>
    /// <param name="id">Id do usuário a ser buscado</param>
    /// <returns>StatusCode 200 e o usuário buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_UsuarioRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// EndPoint da Api que faz a chamada para o metódo de cadastrar um novo usuário
    /// </summary>
    /// <param name="usuario">Usuário a ser cadastrado</param>
    /// <returns>Status code 201 e o usuário</returns>
    [HttpPost]
    public IActionResult Cadastrar(UsuarioDTO usuario)
    {
        try
        {
            var novoUsuario = new Usuario
            {
                Nome = usuario.Name!,
                Email = usuario.Email!,
                Senha = usuario.Password!,
                IdtipoUsuario = usuario.IdTipoUsuario
            };
            _UsuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201, novoUsuario);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
