﻿namespace Ambev.DeveloperEvaluation.Application.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double? Rate { get; set; }
        public int? Count { get; set; }
    }
}
