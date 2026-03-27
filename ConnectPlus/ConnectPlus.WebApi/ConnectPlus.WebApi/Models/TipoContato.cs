using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.WebApi.Models;

[Table("TipoContato")]
public partial class TipoContato
{
    [Key]
    public Guid IdTipoContato { get; set; }

    [StringLength(50)]
    public string Titulo { get; set; } = null!;
    [JsonIgnore]
    [InverseProperty("IdTipoContatoNavigation")]
    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
}
