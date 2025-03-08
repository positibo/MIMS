using System;
using System.Collections.Generic;

namespace MIMS.Api.Source.Domain.Entiities;

public partial class Packaging
{
    public int PackagingId { get; set; }

    public string PackagingType { get; set; } = null!;

    public int? ParentPackagingId { get; set; }

    public int ProductId { get; set; }

    public virtual ICollection<Packaging> InverseParentPackaging { get; set; } = new List<Packaging>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Packaging? ParentPackaging { get; set; }

    public virtual Product Product { get; set; } = null!;
}
