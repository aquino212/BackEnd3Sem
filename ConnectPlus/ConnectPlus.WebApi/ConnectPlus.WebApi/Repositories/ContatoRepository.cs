using ConnectPlus.WebApi.Interfaces;
using ConnectPlus.WebApi.Models;

namespace ConnectPlus.WebApi.Repositories;

using ConnectPlus.WebApi.Models;
using ConnectPlus.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using ConnectPlus.WebApi.DBContextConnect;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _context;

    public ContatoRepository(ConnectContext context)
    {
        _context = context;
    }

    public List<Contato> GetAllContatos()
    {
        return _context.Contatos
            .Include(c => c.IdTipoContato)
            .ToList();
    }

    public Contato GetContatoById(int id)
    {
        return _context.Contatos
            .Include(c => c.IdTipoContato)
            .FirstOrDefault(c => c.IdContato == id);
    }

    public void AddContato(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void UpdateContato(Contato contato)
    {
        var contatoExistente = _context.Contatos
            .FirstOrDefault(c => c.IdContato == contato.IdContato);

        if (contatoExistente != null)
        {
            contatoExistente.Nome = contato.Nome;
            contatoExistente.FormaContato = contato.FormaContato;
            contatoExistente.Imagem = contato.Imagem;
            contatoExistente.IdTipoContato = contato.IdTipoContato;

            _context.SaveChanges();
        }
    }

    public void DeleteContato(int id)
    {
        var contato = _context.Contatos.Find(id);

        if (contato != null)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }
    }
}
