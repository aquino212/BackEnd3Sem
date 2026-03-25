using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("Usuario")]
[Index("Senha", Name = "UQ__Usuario__7ABB973109CF2653", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("IDUsuario")]
    public Guid Idusuario { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [StringLength(50)]
    public string Senha { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [Column("IDTipoUsuario")]
    public Guid? IdtipoUsuario { get; set; }
    [JsonIgnore]
    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<ComentarioEvento> ComentarioEventos { get; set; } = new List<ComentarioEvento>();

    [ForeignKey("IdtipoUsuario")]
    [InverseProperty("Usuarios")]
    public virtual TipoUsuario? IdtipoUsuarioNavigation { get; set; }
    [JsonIgnore]
    [InverseProperty("IdusuarioNavigation")]
    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();
}
