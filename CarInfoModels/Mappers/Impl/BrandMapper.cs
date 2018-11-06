using CarInfoModels.DTOModels;
using CarInfoModels.EntityModels;

namespace CarInfoModels.Mappers.Impl
{
    public class BrandMapper : IBrandMapper
    {
        public BrandDTO Map(Brand source)
        {
            return new BrandDTO
            {
                BrandId = source.BrandId,
                BrandName = source.BrandName,
                CountryName = source.Country.CountryName,
                Description = source.Description,
                PhotoURL = source.PhotoURL
            };
        }
    }
}
