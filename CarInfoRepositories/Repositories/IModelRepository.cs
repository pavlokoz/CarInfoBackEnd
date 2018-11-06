using CarInfoModels.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInfoRepositories.Repositories
{
    public interface IModelRepository: IRepository<Model>
    {
        Task<IList<Model>> GetBrandModels(long brandId);
        Task<IList<Model>> GetTopBrandModels(long brandId);
    }
}
