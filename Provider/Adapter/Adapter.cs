using System;
using System.Reactive.Linq;
using Provider.Adapter.Mapping;

namespace Provider.Adapter
{
    public class Adapter<TSourceKey, TSourceValue, TTargetKey, TTargetValue> : IDisposable
        where TSourceKey : IKey
        where TTargetKey : IKey
        where TSourceValue : IValue
        where TTargetValue : IValue
    {
        private bool _isRunning = true;

        public Adapter(
            IRefCountSubscriber<TSourceKey, TSourceValue> source, 
            IPublisherComponent<TTargetKey, TTargetValue> target,
            IMapper<TSourceKey, TSourceValue, TTargetKey, TTargetValue> mapper)
        {
            source
                .GetUpdates(mapper.SourceKeys)
                .TakeWhile(_ => _isRunning)
                .Subscribe(sourceUpdate =>
                {
                    var targetUpdate = mapper.Map(sourceUpdate);
                    target.Publish(targetUpdate.Key, targetUpdate.Value);
                });
        }

        public void Dispose()
        {
            _isRunning = false;
        }
    }
}
