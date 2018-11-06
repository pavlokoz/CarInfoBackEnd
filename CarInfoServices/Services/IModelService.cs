using CarInfoModels.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInfoServices.Services
{
    public interface IModelService: IService<ModelDTO>
    {
        Task<IList<ModelDTO>> GetBrandModels(long brandId);
        Task<IList<ModelDTO>> GetTopBrandModels(long brandId);
    }
}
