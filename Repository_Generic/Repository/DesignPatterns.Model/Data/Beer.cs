using System;
using System.Collections.Generic;

namespace DesignPatterns.Model.Data;

public partial class Beer
{
    public long BeerId { get; set; }

    public string? Name { get; set; }

    public string? Style { get; set; }
}
