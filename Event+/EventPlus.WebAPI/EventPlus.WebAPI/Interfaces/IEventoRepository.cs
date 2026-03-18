using EventPlus.WebAPI.Models;
namespace EventPlus.WebAPI.Interfaces;

public interface IEventoRepository
{
    void Cadastrar(Evento evento);
    void Deletar(Guid IdEvento);
    List<Evento> Listar();
    void Atualizar(Guid id,Evento evento);
    Evento BuscarPorId(Guid id);
    List<Evento> ListarPorId(Guid IdUsuario);
    List<Evento> ListarProximo();
    void Atualizar(Evento evento);
}
