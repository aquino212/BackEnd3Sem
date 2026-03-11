using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IPresencaRepository
{
    void Inscrever(Presenca presenca);
    void Deletar(Guid id);
    Presenca BuscarPorIdUsuario(Guid id);
    List<Presenca> Listar();
    List<Presenca> ListarMinhas(Guid IdUsuario);
}
