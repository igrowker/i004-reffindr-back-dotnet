namespace Reffindr.Shared.DTOs.Response.Property
{
    public class PropertyGetResponseDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string Title { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string CountryName { get; set; } = default!;
        public string StateName { get; set; } = default!;
        public decimal Price { get; set; }
        public int Environments { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int Seniority { get; set; }
        public bool Water { get; set; }
        public bool Gas { get; set; }
        public bool Surveillance { get; set; }
        public bool Electricity { get; set; }
        public bool Internet { get; set; }
        public bool Pool { get; set; }
        public bool Garage { get; set; }
        public bool Pets { get; set; }
        public bool Grill { get; set; }
        public bool Elevator { get; set; }
        public bool Terrace { get; set; }
        public string Description { get; set; } = default!;
        public virtual List<string>? Images { get; set; }

    }
}
