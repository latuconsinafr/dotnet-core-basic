using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_basic.Models;

namespace dotnet_basic.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}