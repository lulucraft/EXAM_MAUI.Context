using System;
using System.Collections.Generic;

namespace EXAM_MAUI.Context.Models;

public partial class SousEvenement
{
    public int IdSousEvenement { get; set; }

    public string NomSousEvenement { get; set; } = null!;

    public int IdEvenement { get; set; }

    public virtual Evenement IdEvenementNavigation { get; set; } = null!;
}
