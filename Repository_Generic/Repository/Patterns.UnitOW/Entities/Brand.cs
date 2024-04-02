using System;
using System.Collections.Generic;

namespace Patterns.UnitOW.Entities;

public partial class Brand
{
    public string? Name { get; set; }

    public Guid BrandId { get; set; }

    public virtual ICollection<Beer> Beers { get; set; } = new List<Beer>();
}
