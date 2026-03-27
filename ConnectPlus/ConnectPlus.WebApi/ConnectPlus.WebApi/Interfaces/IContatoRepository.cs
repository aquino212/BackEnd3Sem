using ConnectPlus.WebApi.Models;

namespace ConnectPlus.WebApi.Interfaces;

public interface IContatoRepository
{
    List<Contato> Listar();
    Contato BuscarPoId(Guid id);
    void Adicionar(Contato contato);
    void Atualizar(Guid id,Contato contato);
    void Deletar(Guid id);


}
