using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInfoModels.DTOModels;
using CarInfoModels.Mappers;
using CarInfoRepositories.UnitOfWork;

namespace CarInfoServices.Services.Impl
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IModelMapper modelMapper;

        public ModelService(IUnitOfWorkFactory unitOfWorkFactory, IModelMapper modelMapper)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.modelMapper = modelMapper;
        }

        public async Task<IList<ModelDTO>> GetBrandModels(long brandId)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = await uow.ModelRepository.GetBrandModels(brandId);
                return result.Select(modelMapper.Map).ToList();
            }
        }

        public async Task<ModelDTO> GetById(long id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = await uow.ModelRepository.GetById(id);
                return modelMapper.Map(result);
            }
        }

        public async Task<IList<ModelDTO>> GetTopBrandModels(long brandId)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = await uow.ModelRepository.GetTopBrandModels(brandId);
                return result.Select(modelMapper.Map).ToList();
            }
        }
    }
}
