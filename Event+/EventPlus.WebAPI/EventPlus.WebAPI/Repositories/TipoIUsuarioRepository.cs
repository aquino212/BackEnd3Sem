using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    private readonly EventContext _Context;
    public TipoUsuarioRepository(EventContext context)
    {
        _Context = context;
    }

    /// <summary>
    /// Atualida um TipoUsuario usando o restreamento automático.
    /// </summary>
    /// <param name="id">id do tipo usuario a ser atualizado</param>
    /// <param name="tipoUsuario">Novos dados</param>
    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var TipoUsuarioBuscado = _Context.TipoUsuarios.Find(id);
        if (TipoUsuarioBuscado != null)
        {
            TipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
            _Context.SaveChanges();

        }
    }

    /// <summary>
    ///  Busca um TipoUsuario por seu Id.
    /// </summary>
    /// <param name="id">id do tipo usuario a ser busacado</param>
    /// <returns>Objeto do TipoUsuario com as informações do tipo evento buscado</returns>
    public TipoUsuario BuscarPorId(Guid id)
    {
        return _Context.TipoUsuarios.Find(id);
    }

    /// <summary>
    /// Cadastra um novo TipoUsuario.
    /// </summary>
    /// <param name="tipoUsuario">O tipo de usuario a ser cadastrado</param>
    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _Context.TipoUsuarios.Add(tipoUsuario);
        _Context.SaveChanges();
    }


    /// <summary>
    /// Deleta um tipo de usuario
    /// </summary>
    /// <param name="id">id do tipo do usuario a ser deletado</param>
    public void Deletar(Guid id)
    {
        var TipoUsuarioBuscado = _Context.TipoUsuarios.Find(id);
        if (TipoUsuarioBuscado != null)
        {
            _Context.TipoUsuarios.Remove(TipoUsuarioBuscado);
            _Context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de tipos de usuarios cadastrados
    /// </summary>
    /// <returns>Uma lista de tipo usuario</returns>
    public List<TipoUsuario> Listar()
    {
        return _Context.TipoUsuarios.OrderBy(TipoUsuarios => TipoUsuarios.Usuarios).ToList();
    }
}