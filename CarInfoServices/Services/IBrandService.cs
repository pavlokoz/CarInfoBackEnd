using CarInfoModels.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInfoServices.Services
{
    public interface IBrandService: IService<BrandDTO>
    {
        Task<IList<BrandDTO>> GetTopFourBrands();
        Task<IList<BrandDTO>> GetBrands();
    }
}
