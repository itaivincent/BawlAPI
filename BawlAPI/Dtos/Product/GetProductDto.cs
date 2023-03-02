namespace BawlAPI.Dtos.Product
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int InventoryId { get; set; }
        public float Price { get; set; }
        public int DiscountId { get; set; }
        public string? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
