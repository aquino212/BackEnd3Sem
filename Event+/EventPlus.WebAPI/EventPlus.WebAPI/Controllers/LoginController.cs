using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioRepository _LoginRepository;
    public LoginController(IUsuarioRepository loginRepository)
    {
        _LoginRepository = loginRepository;
    }
    [HttpGet]
    public IActionResult Login(LoginDTO loginDto)
    {
        try
        {
            Usuario usuarioBuscado = _LoginRepository.BuscarPorEmailESenha(loginDto.Email!, loginDto.Senha!);
            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome),
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventplus-chave-autenticacao-webapi-dev"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "EventPlus.WebAPI",
                audience: "EventPlus.WebAPI",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
