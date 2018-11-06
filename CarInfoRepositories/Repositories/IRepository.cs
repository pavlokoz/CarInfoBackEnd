using System.Threading.Tasks;

namespace CarInfoRepositories.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(long id);
    }
}
