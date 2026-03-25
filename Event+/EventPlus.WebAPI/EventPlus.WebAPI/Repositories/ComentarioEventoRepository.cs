using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly EventContext _Context;
    public ComentarioEventoRepository(EventContext context)
    {
        _Context = context;
    }

    public void Atualizar(Guid id, ComentarioEvento comentario)
    {
        var comentarioBuscado = _Context.ComentarioEventos.Find(id);
        if (comentarioBuscado != null)
        {
            comentarioBuscado.Descricao = comentario.Descricao;
            comentarioBuscado.Exibe = comentario.Exibe;
            comentarioBuscado.Data = comentario.Data;
            _Context.SaveChanges();
        }


    }

    public ComentarioEvento BuscarPorId(Guid IdEvento)
    {
        throw new NotImplementedException();
    }

    public ComentarioEvento BuscarPorIdUsuario(Guid Usuario, Guid IdEvento)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(ComentarioEvento comentario)
    {
        _Context.ComentarioEventos.Add(comentario);
        _Context.SaveChanges();
    }

    public void Deletar(Guid IdComentario)
    {
        var comentarioBuscado = _Context.ComentarioEventos.Find(IdComentario);
        if (comentarioBuscado != null)
        {
            _Context.ComentarioEventos.Remove(comentarioBuscado);
            _Context.SaveChanges();
        }

    }

    public List<ComentarioEvento> Listar(Guid IdEvento)
    {
        return _Context.ComentarioEventos.Where(c => c.Idevento == IdEvento).ToList();

    }

    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        return _Context.ComentarioEventos
            .Where(c => c.Idevento == IdEvento && c.Exibe)
            .OrderByDescending(c => c.Data)
            .ToList();
    }
}
