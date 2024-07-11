using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Caching;

public interface ICachableRequest
{
    public string CacheKey { get; } //bir anahtar vasıtasıyla cacahe bilgisi oluşturucağız ve bu anahtar ile cache bilgisine ulaşacağız.
    bool BypassCache { get; } //cache bilgisini atlamak için kullanılacak bir property  
    TimeSpan? SlidingExpiration { get; } //cache bilgisinin ne zaman silineceğini belirleyen bir property
}
