using ConnectPlus.WebApi.Models;

namespace ConnectPlus.WebApi.Interfaces;

public interface IContatoRepository
{
    Task<IEnumerable<Contato>> GetAllContatosAsync();
        Task<Contato> GetContatoByIdAsync(int id);
        Task AddContatoAsync(Contato contato);
        Task UpdateContatoAsync(Contato contato);
        Task DeleteContatoAsync(int id);


}
