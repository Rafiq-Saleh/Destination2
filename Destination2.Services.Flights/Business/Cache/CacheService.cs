using System;
using System.Runtime.Caching;

namespace Destination2.Services.Flights.Business.Cache
{
    public enum CacheServiceEnum
    {
        GatewayToken
    }

    public interface ICacheService<in TEnumType>
    {
        bool ItemExists(TEnumType cacheServiceEnum);
        bool ItemExists(TEnumType cacheServiceEnum, string suffix);
        T GetItem<T>(TEnumType cacheServiceEnum);
        T GetItem<T>(TEnumType cacheServiceEnum, string suffix);
        void SetItem<T>(TEnumType cacheServiceEnum, T objectToSave);
        void SetItem<T>(TEnumType cacheServiceEnum, string suffix, T objectToSave);
        void DeleteItem(TEnumType cacheServiceEnum);
        void DeleteItem(TEnumType cacheServiceEnum, string suffix);
    }

     public class CacheService : ICacheService<CacheServiceEnum>
        {
            private readonly ObjectCache _cache;

            public CacheService(ObjectCache cache)
            {
                _cache = cache;
            }

            public bool ItemExists(CacheServiceEnum cacheServiceEnum)
            {
                return ItemExists(cacheServiceEnum, String.Empty);
            }

            public bool ItemExists(CacheServiceEnum cacheServiceEnum, string suffix)
            {
                var key = String.Concat(cacheServiceEnum.ToString(), suffix);
                if (!_cache.Contains(key))
                    return false;

                return _cache[key] != null;
            }

            public T GetItem<T>(CacheServiceEnum cacheServiceEnum)
            {
                return GetItem<T>(cacheServiceEnum, String.Empty);
            }

            public T GetItem<T>(CacheServiceEnum cacheServiceEnum, string suffix)
            {
                var key = String.Concat(cacheServiceEnum.ToString(), suffix);
                try
                {
                    return (T)_cache[key];
                }
                catch (Exception ex)
                {
                throw ex;
                }
            }

            public void SetItem<T>(CacheServiceEnum cacheServiceEnum, T objectToSave)
            {
                SetItem(cacheServiceEnum, String.Empty, objectToSave);
            }

            public void SetItem<T>(CacheServiceEnum cacheServiceEnum, string suffix, T objectToSave)
            {
                var key = cacheServiceEnum.ToString() + suffix;

                _cache.Set(key, objectToSave, new CacheItemPolicy());
            }

            public void DeleteItem(CacheServiceEnum cacheServiceEnum)
            {
                DeleteItem(cacheServiceEnum, String.Empty);
            }

            public void DeleteItem(CacheServiceEnum cacheServiceEnum, string suffix)
            {
                if (!_cache.Contains(cacheServiceEnum.ToString() + suffix))
                    return;

                _cache.Remove(cacheServiceEnum.ToString() + suffix);
            }
        }
    
}