using System;
using System.Collections.Generic;

namespace DsK.LINQTutorial.Models;

public partial class UserPhoneNumber
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
