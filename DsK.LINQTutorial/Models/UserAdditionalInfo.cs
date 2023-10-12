using System;
using System.Collections.Generic;

namespace DsK.LINQTutorial.Models;

public partial class UserAdditionalInfo
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
