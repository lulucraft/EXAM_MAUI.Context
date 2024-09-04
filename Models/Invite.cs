using System;
using System.Collections.Generic;

namespace EXAM_MAUI.Context.Models;

public partial class Invite
{
    public int IdInvite { get; set; }

    public string EmailInvite { get; set; } = null!;

    public short? NbInviteSupplementaire { get; set; }

    public string TelephoneInvite { get; set; } = null!;

    public string CodeInvite { get; set; } = null!;

    public bool PresenceInvite { get; set; }

    public string PrenomInvite { get; set; } = null!;

    public string NomInvite { get; set; } = null!;

    public virtual ICollection<ConfirmationPresence> ConfirmationPresences { get; set; } = new List<ConfirmationPresence>();

    public virtual ICollection<Evenement> IdEvenements { get; set; } = new List<Evenement>();
}
