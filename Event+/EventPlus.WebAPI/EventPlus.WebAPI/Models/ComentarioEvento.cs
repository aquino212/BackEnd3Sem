using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("ComentarioEvento")]
public partial class ComentarioEvento
{
    [Key]
    [Column("IDComentarioEvento")]
    public Guid IdcomentarioEvento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Data { get; set; }

    public bool Exibe { get; set; }

    [StringLength(250)]
    public string? Descricao { get; set; }

    [Column("IDEvento")]
    public Guid? Idevento { get; set; }

    public Guid? IdUsuario { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("ComentarioEventos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [ForeignKey("Idevento")]
    [InverseProperty("ComentarioEventos")]
    public virtual Evento? IdeventoNavigation { get; set; }
}
