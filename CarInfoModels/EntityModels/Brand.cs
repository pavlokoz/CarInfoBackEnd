namespace CarInfoModels.EntityModels
{
    public class Brand
    {
        public long BrandId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public Country Country { get; set; }
    }
}
