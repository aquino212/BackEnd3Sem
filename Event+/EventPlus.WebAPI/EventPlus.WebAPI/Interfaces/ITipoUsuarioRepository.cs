using EventPlus.WebAPI.Models;
namespace EventPlus.WebAPI.Interfaces;

public interface ITipoUsuarioRepository
{
    void Cadastrar(Models.TipoUsuario tipoUsuario);
    void Deletar(Guid IdTipoUsuario);
    List<Models.TipoUsuario> Listar();
    TipoUsuario BuscarPorId(Guid id);
    void Atualizar(Guid id, TipoUsuario tipoUsuario);
}
