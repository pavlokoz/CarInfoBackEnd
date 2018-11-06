using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInfoModels.DTOModels;
using CarInfoModels.EntityModels;

namespace CarInfoModels.Mappers.Impl
{
    public class FavoriteModelMapper : IFavoriteModelMapper
    {
        public UserFavoriteModel Map(FavoriteModelDTO modelDTO)
        {
            return new UserFavoriteModel
            {
                ModelId = modelDTO.ModelId,
                UserId = modelDTO.UserId
            };
        }

        public FavoriteModelDTO Map(UserFavoriteModel source)
        {
            return new FavoriteModelDTO
            {
                ModelId = source.ModelId,
                UserId = source.UserId
            };
        }
    }
}
