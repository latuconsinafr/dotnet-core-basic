using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace dotnet_basic.Services
{
    public interface ICacheService
    {
        Task<T> GetFromCache<T>(string key) where T : class;
        Task SetCache<T>(string key, T value, DistributedCacheEntryOptions options) where T : class;
        Task ClearCache(string key);
    }
}