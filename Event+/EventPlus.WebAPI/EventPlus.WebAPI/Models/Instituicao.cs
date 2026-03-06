using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("Instituicao")]
[Index("Cnpj", Name = "UQ__Institui__AA57D6B4C5D3BEC0", IsUnique = true)]
public partial class Instituicao
{
    [Key]
    [Column("IDInstituicao")]
    public Guid Idinstituicao { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [StringLength(250)]
    public string? Endereco { get; set; }

    [Column("CNPJ")]
    [StringLength(14)]
    public string Cnpj { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("IdinstituicaoNavigation")]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
