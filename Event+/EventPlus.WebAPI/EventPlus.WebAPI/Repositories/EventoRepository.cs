using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _Context;
    public EventoRepository(EventContext context)
    {
        _Context = context;
    }

     public void Atualizar(Guid id, Evento evento)
    {
        var EventoBuscado = _Context.Eventos.Find(id);
        if (EventoBuscado != null)
        {
            EventoBuscado.Nome = evento.Nome;
            EventoBuscado.Descricao = evento.Descricao;
            EventoBuscado.Data = evento.Data;
            EventoBuscado.IdtipoEvento = evento.IdtipoEvento;
            EventoBuscado.Idinstituicao = evento.Idinstituicao;
            _Context.Eventos.Update(EventoBuscado);
            _Context.SaveChanges();
        }
    }

    public void Atualizar(Evento evento)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca um evento no banco de dados utilizando o Id do evento para encontrar o evento desejado
    /// </summary>
    /// <param name="id">id do evento a ser busacado</param>
    /// <returns>Objeto do Evento com as informações da instituicao buscado</returns>
    public Evento BuscarPorId(Guid id)
    {
        return _Context.Eventos.Find(id);
    }

    /// <summary>
    /// Cadastra um novo evento no banco de dados, utilizando os dados do evento passado como parâmetro
    /// </summary>
    /// <param name="evento">O evento a ser cadastrado</param>
    public void Cadastrar(Evento evento)
    {
        _Context.Eventos.Add(evento);
        _Context.SaveChanges();
    }

    /// <summary>
    /// Deleta um evento do banco de dados, utilizando o Id do evento para encontrar o evento a ser deletado
    /// </summary>
    /// <param name="IdEvento">id do evento a ser deletado</param>
    public void Deletar(Guid IdEvento)
    {
        var EventoBuscado = _Context.Eventos.Find(IdEvento);
        if (EventoBuscado != null)
        {
            _Context.Eventos.Remove(EventoBuscado);
            _Context.SaveChanges();
        }
    }

    /// <summary>
    /// Lista todos os eventos cadastrados ordenando por nome do evento
    /// </summary>
    /// <returns>Uma lista de Evento </returns>
    public List<Evento> Listar()
    {
        return _Context.Eventos.ToList();
    }

    /// <summary>
    /// Método que lista eventos filtrando pelas presenças de um usuário
    /// </summary>
    /// <param name="IdUsuario">Id do usuário para filtragem </param>
    /// <returns>Retorna uma lista de eventpos filtrados por usuário</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _Context.Eventos.Include(e => e.IdinstituicaoNavigation)
                               .Include(e => e.IdtipoEventoNavigation)
                               .Where(e => e.Presencas.Any(p => p.Idusuario == IdUsuario && p.Situacao == true))
                               .ToList();
    }

    /// <summary>
    /// Método que retorna os proximos eventos que vão acontecer
    /// </summary>
    /// <returns>Ele retorna uma lista de proximos eventos</returns>
    public List<Evento> ListarProximo()
    {
        return
        _Context.Eventos.Include(e => e.IdinstituicaoNavigation)
                       .Include(e => e.IdtipoEventoNavigation)
                       .Where(e => e.Data > DateTime.Now)
                       .OrderBy(e => e.Data)
                       .ToList();
    }
}
