using CarInfoModels.DTOModels;
using CarInfoRepositories.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInfoServices.Services
{
    public interface IFavoriteModelService: IService<FavoriteModelDTO>
    {
        Task<bool> CheckExistFavoriteUserModel(FavoriteModelDTO model);
        Task<IList<long>> GetUsersFavoriteModelIds(int userId);
        Task<IList<ModelDTO>> GetUserFavoriteModels(int userId);
        Task<bool> SetUserFavoriteModel(FavoriteModelDTO favoriteModel);
        Task<bool> DeleteUserFavoriteModel(FavoriteModelDTO favoriteModel);
    }
}
