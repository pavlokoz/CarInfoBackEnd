using System.Threading.Tasks;

namespace CarInfoServices.Services
{
    public interface IService<T>
    {
        Task<T> GetById(long id);
    }
}
