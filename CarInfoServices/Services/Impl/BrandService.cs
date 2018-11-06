using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInfoModels.DTOModels;
using CarInfoModels.Mappers;
using CarInfoModels.Mappers.Impl;
using CarInfoRepositories.UnitOfWork;

namespace CarInfoServices.Services.Impl
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IBrandMapper brandMapper;

        public BrandService(IUnitOfWorkFactory unitOfWorkFactory, IBrandMapper brandMapper)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.brandMapper = brandMapper;
        }

        public async Task<IList<BrandDTO>> GetBrands()
        {
            using (var uof = unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = await uof.BrandRepository.GetBrands();
                return result.Select(brandMapper.Map).ToList();
            }
        }

        public async Task<BrandDTO> GetById(long id)
        {
            using (var uof = unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = await uof.BrandRepository.GetById(id);
                return brandMapper.Map(result);
            }
        }

        public async Task<IList<BrandDTO>> GetTopFourBrands()
        {
            using (var uof = unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = await uof.BrandRepository.GetTopFourBrands();
                return result.Select(brandMapper.Map).ToList();
            }
        }
    }
}
