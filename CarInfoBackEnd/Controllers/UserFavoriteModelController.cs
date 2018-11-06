using CarInfoModels.DTOModels;
using CarInfoServices.Services;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarInfoBackEnd.Controllers
{
    [Authorize]
    public class UserFavoriteModelController : ApiController
    {
        private readonly IFavoriteModelService favoriteModelService;

        public UserFavoriteModelController(IFavoriteModelService favoriteModelService)
        {
            this.favoriteModelService = favoriteModelService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> CheckExistFavoriteUserModel(long modelId)
        {
            var result = await favoriteModelService.CheckExistFavoriteUserModel(new FavoriteModelDTO
            {
                UserId = User.Identity.GetUserId<int>(),
                ModelId = modelId
            });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUserFavoriteModels()
        {
            var result = await favoriteModelService.GetUserFavoriteModels(User.Identity.GetUserId<int>());
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUsersFavoriteModelIds()
        {
            var result = await favoriteModelService.GetUsersFavoriteModelIds(User.Identity.GetUserId<int>());
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SetUserFavoriteModel([FromUri]long modelId)
        {
            var result = await favoriteModelService.SetUserFavoriteModel(new FavoriteModelDTO
            {
                UserId = User.Identity.GetUserId<int>(),
                ModelId = modelId
            });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUserFavoriteModel([FromUri]long modelId)
        {
            var result = await favoriteModelService.DeleteUserFavoriteModel(new FavoriteModelDTO
            {
                UserId = User.Identity.GetUserId<int>(),
                ModelId = modelId
            });
            return Ok(result);
        }
    }
}
