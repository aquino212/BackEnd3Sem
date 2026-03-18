using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IPresencaRepository
{
    void Inscrever(Presenca presenca);
    void Deletar(Guid id);
    Presenca BuscarPorId(Guid id);
    List<Presenca> Listar();
    List<Presenca> ListarMinhas(Guid IdUsuario);
    void Atualizar(Guid id, Presenca presenca);
    Presenca BuscarPorIdUsuario(Guid id);

}
