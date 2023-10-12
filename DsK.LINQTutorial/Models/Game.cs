﻿using System;
using System.Collections.Generic;

namespace DsK.LINQTutorial.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
