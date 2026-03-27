using ConnectPlus.WebApi.Models;

namespace ConnectPlus.WebApi.Interfaces;

public interface ITipoContatoRepository
{
    void Adicionar(TipoContato tipoContato);
    void Atualizar(TipoContato tipoContato);
    TipoContato BuscarPoId(int id);
    List<TipoContato> Listar();
    void Deletar(int id);
     
}
