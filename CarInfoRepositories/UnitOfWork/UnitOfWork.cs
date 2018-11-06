using CarInfoRepositories.Repositories;
using CarInfoRepositories.Repositories.Impl;

namespace CarInfoRepositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IBrandRepository brandRepository;
        private IModelRepository modelRepository;
        private IFavoriteModelRepository favoriteModelRepository;

        public IBrandRepository BrandRepository => brandRepository ?? (brandRepository = new BrandRepository());
        public IModelRepository ModelRepository => modelRepository ?? (modelRepository = new ModelRepository());
        public IFavoriteModelRepository FavoriteModelRepository => favoriteModelRepository ?? 
                                       (favoriteModelRepository = new FavoriteModelRepository());

        public void Dispose()
        {
        }
    }
}
