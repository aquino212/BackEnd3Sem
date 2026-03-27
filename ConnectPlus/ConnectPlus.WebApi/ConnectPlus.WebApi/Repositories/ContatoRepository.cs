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

    public void Adicionar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var contato = _context.Contatos.Find(id);

        if (contato != null)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }
    }

    public List<Contato> Listar()
    {
            return _context.Contatos
        .Include(c => c.IdTipoContatoNavigation)
        .ToList();
    }

    public Contato BuscarPoId(Guid id)
    {
        return _context.Contatos
        .Include(c => c.IdTipoContatoNavigation)
        .FirstOrDefault(c => c.IdContato == id);
    }
    public void Atualizar(Guid id, Contato contato)
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

}
