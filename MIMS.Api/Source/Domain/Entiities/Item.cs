using System;
using System.Collections.Generic;

namespace MIMS.Api.Source.Domain.Entiities;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public int PackagingId { get; set; }

    public virtual Packaging Packaging { get; set; } = null!;
}
