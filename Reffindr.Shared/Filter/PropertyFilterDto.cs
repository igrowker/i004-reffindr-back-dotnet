namespace Reffindr.Shared.DTOs.Filter
{
    public class PropertyFilterDto
    {
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public bool? IsWorking { get; set; }
        public bool? HasWarranty { get; set; }
        public decimal? RangeSalaryMin { get; set; }
        public decimal? RangeSalaryMax { get; set; }
        public string? Title { get; set; }
    }

}
