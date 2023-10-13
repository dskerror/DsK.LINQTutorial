using System;
using System.Collections.Generic;

namespace DsK.LINQTutorial.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual UserAdditionalInfo? UserAdditionalInfo { get; set; }

    public virtual ICollection<UserPhoneNumber> UserPhoneNumbers { get; set; } = new List<UserPhoneNumber>();

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
