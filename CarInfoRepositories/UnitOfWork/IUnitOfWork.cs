using CarInfoRepositories.Repositories;
using System;

namespace CarInfoRepositories.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IBrandRepository BrandRepository { get; }
        IModelRepository ModelRepository { get; }
        IFavoriteModelRepository FavoriteModelRepository { get; }
    }
}
