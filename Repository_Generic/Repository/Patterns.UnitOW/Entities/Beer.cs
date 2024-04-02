using System;
using System.Collections.Generic;

namespace Patterns.UnitOW.Entities;

public partial class Beer
{
    public string? Name { get; set; }

    public string? Style { get; set; }

    public Guid BeerId { get; set; }

    public Guid? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }
}
