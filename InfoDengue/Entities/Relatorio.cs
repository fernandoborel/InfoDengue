using System;
using System.Collections.Generic;

namespace InfoDengue.Entities;

public partial class Relatorio
{
    public int IdSolicitanteRelatorio { get; set; }

    public DateOnly DataSolicitacao { get; set; }

    public string Arbovirose { get; set; } = null!;

    public string CpfSolicitante { get; set; } = null!;

    public int SemInicio { get; set; }

    public int SemTermino { get; set; }

    public int CodIbge { get; set; }

    public string Municipio { get; set; } = null!;

    public virtual Solicitante CpfSolicitanteNavigation { get; set; } = null!;
}
