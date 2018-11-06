using CarInfoModels.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInfoRepositories.Repositories
{
    public interface IBrandRepository: IRepository<Brand>
    {
        Task<IList<Brand>> GetBrands();
        Task<IList<Brand>> GetTopFourBrands();
    }
}
