using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace WeatherApi.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class CustomCacheAttribute : ActionFilterAttribute
{
    public CustomCacheAttribute(int duration, string key)
    {
        Duration = duration;
        Key = key;
    }

    // private readonly IMemoryCache _cache;
    public int Duration { get; set; }
    public string Key { get; set; }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var cache = context.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();

        // Implement the cache logic here
        if (!cache.TryGetValue(Key, out _)) cache.Set(Key, context.Result, TimeSpan.FromSeconds(Duration));

        base.OnActionExecuted(context);
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var cache = context.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
        // Implement the cache logic here
        if (cache.TryGetValue(Key, out IActionResult? result))
        {
            context.Result = result;
            return;
        }

        base.OnActionExecuting(context);
    }
}