using System.Collections.Generic;
using System.Linq;
using CarInfoModels.DTOModels;
using CarInfoModels.EntityModels;

namespace CarInfoModels.Mappers.Impl
{
    public class ModelMapper : IModelMapper
    {
        public ModelDTO Map(Model source)
        {
            return new ModelDTO
            {
                ModelName = source.ModelName,
                ModelId = source.ModelId,
                AddInfo = source.AddInfo,
                CarTypeName = source.Type?.CarType?.CarTypeName,
                TypeName = source.Type?.TypeName,
                TypeId = source.Type?.TypeId,
                PhotoURL = source.PhotoURL,
                BrandName = source.Brand?.BrandName,
                Photos = source.Photos,
                FuelTypes = source.FuelTypes?.Select(x =>  new KeyValuePair<short?, string>(x?.FuelId, x?.FuelName)).ToList()
            };
        }
    }
}
