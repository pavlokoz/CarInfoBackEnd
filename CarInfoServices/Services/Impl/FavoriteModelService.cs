using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInfoModels.DTOModels;
using CarInfoModels.Mappers;
using CarInfoRepositories.UnitOfWork;

namespace CarInfoServices.Services.Impl
{
    public class FavoriteModelService : IFavoriteModelService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IFavoriteModelMapper favoriteModelMapper;
        private readonly IModelMapper modelMapper;

        public FavoriteModelService(IFavoriteModelMapper favoriteModelMapper, 
            IModelMapper modelMapper, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.modelMapper = modelMapper;
            this.favoriteModelMapper = favoriteModelMapper;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<bool> CheckExistFavoriteUserModel(FavoriteModelDTO model)
        {
            using (var uof = unitOfWorkFactory.CreateUnitOfWork())
            {
                return await uof.FavoriteModelRepository.
                    CheckExistFavoriteUserModel(favoriteModelMapper.Map(model));
            }
        }

        public Task<FavoriteModelDTO> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ModelDTO>> GetUserFavoriteModels(int userId)
        {
            using (var uof = unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = await uof.FavoriteModelRepository.GetUserFavoriteModels(userId);
                return result.Select(modelMapper.Map).ToList();
            }
        }

        public async Task<IList<long>> GetUsersFavoriteModelIds(int userId)
        {
            using (var uof = unitOfWorkFactory.CreateUnitOfWork())
            {
                return await uof.FavoriteModelRepository.GetUsersFavoriteModelIds(userId);
            }
        }

        public async Task<bool> SetUserFavoriteModel(FavoriteModelDTO favoriteModel)
        {
            using (var uof = unitOfWorkFactory.CreateUnitOfWork())
            {
                return await uof.FavoriteModelRepository.
                    SetUserFavoriteModel(favoriteModelMapper.Map(favoriteModel));
            }
        }

        public async Task<bool> DeleteUserFavoriteModel(FavoriteModelDTO favoriteModel)
        {
            using (var uof = unitOfWorkFactory.CreateUnitOfWork())
            {
                return await uof.FavoriteModelRepository.
                    DeleteUserFavoriteModel(favoriteModelMapper.Map(favoriteModel));
            }
        }
    }
}
