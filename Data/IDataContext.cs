using System.Threading;
using System.Threading.Tasks;
using dotnet_basic.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_basic.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products {get; set;}
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}