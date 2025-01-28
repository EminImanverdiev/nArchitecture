using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Caching;

public interface ICachableRequest
{
    public string Cachekey { get;  }
    public bool BypassCache { get;  }
    public TimeSpan? SlidingExpiration { get; }
}
