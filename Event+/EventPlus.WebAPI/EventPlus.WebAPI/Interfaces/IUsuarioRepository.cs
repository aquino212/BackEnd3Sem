using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    Usuario BuscarPorId(Guid IdUsuario);
    Usuario BuscarPorEmailESenha(string Email, string Senha);
    Usuario BuscarPorEmailESenha(object value1, object value2);
}
