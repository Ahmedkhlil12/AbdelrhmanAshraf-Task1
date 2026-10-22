namespace Task_1.DTOs
{
    public class ProductV2Dto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string? Description { get; set; }
    }
}
