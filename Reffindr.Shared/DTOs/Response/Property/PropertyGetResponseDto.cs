namespace Reffindr.Shared.DTOs.Response.Property
{
    public class PropertyGetResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CountryName { get; set; } = default!;
        public string StateName { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
