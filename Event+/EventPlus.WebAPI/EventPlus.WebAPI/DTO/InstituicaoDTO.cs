using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O nome da instituição é obrigatório!")]
    public string? Nome { get; set; }
}
