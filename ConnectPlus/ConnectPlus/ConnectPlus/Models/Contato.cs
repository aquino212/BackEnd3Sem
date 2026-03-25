using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contato")]
public partial class Contato
{
    [Key]
    public int IdContato { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(100)]
    public string FormaContato { get; set; } = null!;

    [StringLength(255)]
    public string? Imagem { get; set; }

    public int IdTipoContato { get; set; }

    [ForeignKey("IdTipoContato")]
    [InverseProperty("Contatos")]
    public virtual TipoContato IdTipoContatoNavigation { get; set; } = null!;
}
