using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class TipoUsuarioDTO
{
    [Required(ErrorMessage = "O Id do tipo de usuário é obrigatório!")]
    public string? Id { get; set; }
}
