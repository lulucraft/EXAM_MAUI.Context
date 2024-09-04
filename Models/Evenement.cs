using System;
using System.Collections.Generic;

namespace EXAM_MAUI.Context.Models;

public partial class Evenement
{
    public int IdEvenement { get; set; }

    public string Nom { get; set; } = null!;

    public string LieuEvenement { get; set; } = null!;

    public string CoordonneesGps { get; set; } = null!;

    public DateTime DateEvenement { get; set; }

    public short NbInvites { get; set; }

    public virtual ICollection<ConfirmationPresence> ConfirmationPresences { get; set; } = new List<ConfirmationPresence>();

    public virtual ICollection<SousEvenement> SousEvenements { get; set; } = new List<SousEvenement>();

    public virtual ICollection<Invite> IdInvites { get; set; } = new List<Invite>();
}
