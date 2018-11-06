using CarInfoModels.Mappers;
using CarInfoModels.Mappers.Impl;
using CarInfoRepositories.UnitOfWork;
using CarInfoServices.Services;
using CarInfoServices.Services.Impl;
using Unity;

namespace CarInfoBackEnd.Unity
{
    public class TypeRegistrator
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<IModelService, ModelService>();
            container.RegisterType<IBrandMapper, BrandMapper>();
            container.RegisterType<IModelMapper, ModelMapper>();
            container.RegisterType<IFavoriteModelService, FavoriteModelService>();
            container.RegisterType<IFavoriteModelMapper, FavoriteModelMapper>();
            container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }
    }
}