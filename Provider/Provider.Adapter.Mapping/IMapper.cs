using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Provider.Adapter.Mapping
{
    public interface IMapper<TSourceKey, TSourceValue, TTargetKey, TTargetValue>
    {
        TSourceKey SourceKeys { get; set; }
        KeyValuePair<TTargetKey, TTargetValue> Map(KeyValuePair<TSourceKey, TSourceValue> sourceValue);
    }
}
