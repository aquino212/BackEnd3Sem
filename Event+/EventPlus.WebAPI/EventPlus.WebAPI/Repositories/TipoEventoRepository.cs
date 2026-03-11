using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class TipoEventoRepository : ITipoEventoRepository
{
    private readonly EventContext _Context;
    public TipoEventoRepository(EventContext context)
    {
        _Context = context;
    }
    /// <summary>
    /// Atualida um TipoEvento usando o restreamento automático.
    /// </summary>
    /// <param name="id">id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">Novos dados </param>
    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var TipoEventoBuscado = _Context.TipoEventos.Find(id);
        if (TipoEventoBuscado != null)
        {
            TipoEventoBuscado.Titulo = tipoEvento.Titulo;
            _Context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um TipoEvento por seu Id.
    /// </summary>
    /// <param name="id">id do tipo evento a ser busacado</param>
    /// <returns>Objeto do TipoEvento com as informações do tipo evento buscado</returns>
    public TipoEvento BuscarPorId(Guid id)
    {
        return _Context.TipoEventos.Find(id);
    }

    /// <summary>
    /// Cadastra um novo TipoEvento.
    /// </summary>
    /// <param name="tipoEvento">O tipo de evento a ser cadastrado</param>
    public void Cadastrar(TipoEvento tipoEvento)
    {
        _Context.TipoEventos.Add(tipoEvento);
        _Context.SaveChanges();
    }

    /// <summary>
    /// Deleta um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo do evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var TipoEventoBuscado = _Context.TipoEventos.Find(id);
        if (TipoEventoBuscado != null)
        {
            _Context.TipoEventos.Remove(TipoEventoBuscado);
            _Context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de tipos de eventos cadastrados
    /// </summary>
    /// <returns>Uma lista de tipo eventos</returns>
    public List<TipoEvento> Listar()
    {
        return _Context.TipoEventos.OrderBy(TipoEvento => TipoEvento.Titulo).ToList();
    }
}
