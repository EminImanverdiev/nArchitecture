﻿using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Core.Application.Pipelines.Caching;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICachableRequest
{
    private readonly CacheSettings _cacheSettings;
    private readonly IDistributedCache _cache;
    private readonly ILogger<CachingBehavior<TRequest,TResponse>> _logger;

    public CachingBehavior(IDistributedCache cache, IConfiguration configuration, ILogger<CachingBehavior<TRequest, TResponse>> logger)
    {
        _cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>() ?? throw new InvalidOperationException();
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request.BypassCache)
        {
            return await next();
        }
        TResponse response;
        byte[]? cachedResponse=await _cache.GetAsync(request.Cachekey,cancellationToken);
        if (cachedResponse != null)
        {
            response=JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cachedResponse));
            _logger.LogInformation($"Fetched from Cache--> {request.Cachekey}");
        }
        else
        {
            response = await getResponseAndAddToCache(request,next,cancellationToken);
        }
        return response;
    }

    private async Task<TResponse?> getResponseAndAddToCache(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        TResponse response=await next();
        TimeSpan slidingExpiration = request.SlidingExpiration ?? TimeSpan.FromDays(_cacheSettings.SlidingExpiration);
        DistributedCacheEntryOptions cacheOptions = new() { SlidingExpiration=slidingExpiration };
        byte[] serializedData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response));
        await _cache.SetAsync(request.Cachekey,serializedData,cacheOptions,cancellationToken);
        return response;

    }
}
