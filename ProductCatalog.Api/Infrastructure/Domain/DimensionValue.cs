﻿namespace ProductCatalog.Api.Infrastructure.Domain
{
    public class DimensionValue
    {
        public Guid Id { get; set; }
        public Guid DimensionId { get; set; }
        public string Value { get; set; } = default!;
    }
}
