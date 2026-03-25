using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class EventoDTO
{
    public string? Nome { get; set; }
    public DateTime Data { get; set; }
    public string? Descricao { get; set; }
    public Guid? IdtipoEvento { get; set; }
    public Guid? Idinstituicao { get; set; }
}
