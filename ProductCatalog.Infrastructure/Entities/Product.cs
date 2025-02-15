﻿using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.Infrastructure.Entities
{
    [Index(nameof(TenantId))]
    public class Product : ITenancyEntity
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string[] Images { get; set; } = [];
        public ICollection<Variant> Variants { get; set; } = [];
    }
}
