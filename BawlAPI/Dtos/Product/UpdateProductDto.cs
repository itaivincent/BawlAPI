﻿namespace BawlAPI.Dtos.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int InventoryId { get; set; }
        public float Price { get; set; }
        public int DiscountId { get; set; }

    }
}
