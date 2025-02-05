using System;
using System.Collections.Generic;

namespace InfoDengue.Entities;

public partial class Solicitante
{
    public int IdSolicitante { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public virtual ICollection<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
}
