using CarInfoModels.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInfoRepositories.Repositories
{
    public interface IFavoriteModelRepository: IRepository<UserFavoriteModel>
    {
        Task<bool> CheckExistFavoriteUserModel(UserFavoriteModel userFavoriteModel);
        Task<IList<long>> GetUsersFavoriteModelIds(int userId);
        Task<IList<Model>> GetUserFavoriteModels(int userId);
        Task<bool> SetUserFavoriteModel(UserFavoriteModel favoriteModel);
        Task<bool> DeleteUserFavoriteModel(UserFavoriteModel favoriteModel);
    }
}
