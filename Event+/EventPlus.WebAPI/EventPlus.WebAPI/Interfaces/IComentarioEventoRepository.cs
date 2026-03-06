using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IComentarioEventoRepository
{
    void Cadastrar(ComentarioEvento comentarioEvento);
    void Deletar(Guid IdComentarioEvento);
    List<ComentarioEvento> Listar(Guid IdEvento);
    ComentarioEvento BuscarPorIdUsuario(Guid Usuario,Guid IdEvento);
    List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento);
}
