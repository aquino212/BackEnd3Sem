using ConnectPlus.WebApi.DBContextConnect;
using ConnectPlus.WebApi.Interfaces;
using ConnectPlus.WebApi.Models;

namespace ConnectPlus.WebApi.Repositories;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly ConnectContext _context;
    public TipoContatoRepository(ConnectContext context)
    {
        _context = context;
    }
    public void Adicionar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }
    public void Atualizar(TipoContato tipoContato)
    {
        _context.TipoContatos.Update(tipoContato);
        _context.SaveChanges();
    }
    public TipoContato BuscarPoId(int id)
    {
        return _context.TipoContatos.Find(id);
    }
    public List<TipoContato> Listar()
    {
        return _context.TipoContatos.ToList();
    }
    public void Deletar(int id)
    {
        var tipoContato = _context.TipoContatos.Find(id);
        if (tipoContato != null)
        {
            _context.TipoContatos.Remove(tipoContato);
            _context.SaveChanges();
        }
    }

}
