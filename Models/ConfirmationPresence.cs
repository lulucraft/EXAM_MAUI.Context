using System;
using System.Collections.Generic;

namespace EXAM_MAUI.Context.Models;

public partial class ConfirmationPresence
{
    public int IdConfirmation { get; set; }

    public bool Confirmation { get; set; }

    public DateTime DateConfirmation { get; set; }

    public int IdEvenement { get; set; }

    public int IdInvite { get; set; }

    public virtual Evenement IdEvenementNavigation { get; set; } = null!;

    public virtual Invite IdInviteNavigation { get; set; } = null!;
}
