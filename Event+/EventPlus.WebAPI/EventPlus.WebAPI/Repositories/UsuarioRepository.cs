using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _Context;
    public UsuarioRepository(EventContext context)
    {
        _Context = context;
    }

    /// <summary>
    /// Ele busca o usuário pelo Email e valida pelo hash da senha
    /// </summary>
    /// <param name="Email">Email do usuário </param>
    /// <param name="Senha">Senha do Usuário</param>
    /// <returns>Usuário buscado e valido</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {   
        var usuarioBuscado = _Context.Usuarios.Include(Usuario => Usuario.IdtipoUsuarioNavigation).FirstOrDefault(Usuario => Usuario.Email == Email)!;
        if (usuarioBuscado != null)
        {
            bool confere = Cryptografia.CompararHash(Senha, usuarioBuscado.Senha);
            if (confere)
            {
                return usuarioBuscado;
            }
            
        }
        return null!;
    }

    /// <summary>
    /// Buscado um usuário por seu Id, incluindo os dados do seu tipo usuário
    /// </summary>
    /// <param name="IdUsuario">Id do usuário a ser buscado</param>
    /// <returns>Usuário buscado</returns>
    public Usuario BuscarPorId(Guid IdUsuario)
    {
        return _Context.Usuarios.Include(Usuario => Usuario.IdtipoUsuarioNavigation).FirstOrDefault(Usuario => Usuario.Idusuario == IdUsuario)!;
    }

    /// <summary>
    /// Cadastra um novo usuario com a senha criptografada
    /// </summary>
    /// <param name="usuario">Usuário a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Cryptografia.GerarHash(usuario.Senha);
        _Context.Usuarios.Add(usuario);
        _Context.SaveChanges();
    }
}
