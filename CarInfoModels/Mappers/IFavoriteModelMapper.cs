using CarInfoModels.DTOModels;
using CarInfoModels.EntityModels;

namespace CarInfoModels.Mappers
{
    public interface IFavoriteModelMapper: IMapper<UserFavoriteModel, FavoriteModelDTO>
    {
        UserFavoriteModel Map(FavoriteModelDTO modelDTO);
    }
}
