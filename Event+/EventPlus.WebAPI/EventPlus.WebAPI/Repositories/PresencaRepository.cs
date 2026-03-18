using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;


public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _context;
    public PresencaRepository(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Método que alterna a situacao da presença
    /// </summary>
    /// <param name="id">id da presenca a ser alterada</param>
    /// <param name="presenca"></param>
    public void Atualizar(Guid id, Presenca presenca)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }

    }
    public Presenca BuscarPorId(Guid IdUsuario)
    {
        return _context.Presencas
            .Include(p => p.IdeventoNavigation)
            .ThenInclude(e => e.IdinstituicaoNavigation)
            .FirstOrDefault(p => p.Idusuario == IdUsuario)!;
    }

    public Presenca BuscarPorIdUsuario(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Deletar(Guid id, Presenca presenca)
    {
        var presencaBuscada = _context.Presencas.Find(id);
        if (presencaBuscada != null)
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }

    public List<Presenca> Listar()
    {
        return _context.Presencas
            .Include(p => p.IdusuarioNavigation)
            .ToList();
    }

    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas
            .Include(p => p.IdeventoNavigation)
            .ThenInclude(e => e!.IdinstituicaoNavigation)
            .Where(p => p.Idusuario == IdUsuario)
            .ToList();
    }
}