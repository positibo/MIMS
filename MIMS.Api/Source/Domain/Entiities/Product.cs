using System;
using System.Collections.Generic;

namespace MIMS.Api.Source.Domain.Entiities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public virtual ICollection<Packaging> Packagings { get; set; } = new List<Packaging>();
}
