using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Provider
{
    public class RefCountSubscriber<TKey, TValue> : IRefCountSubscriber<TKey, TValue>
        where TKey : IKey
        where TValue : IValue
    {
        private readonly ISubscriberComponent<TKey,TValue> _subscriberComponent;

        private readonly ConcurrentDictionary<TKey, ISubject<KeyValuePair<TKey, TValue>>> _subjects = 
            new ConcurrentDictionary<TKey, ISubject<KeyValuePair<TKey,TValue>>>();

        private readonly ConcurrentDictionary<TKey, IObservable<KeyValuePair<TKey, TValue>>> _observables = 
            new ConcurrentDictionary<TKey, IObservable<KeyValuePair<TKey, TValue>>>();

        public RefCountSubscriber(ISubscriberComponent<TKey, TValue> subscriberComponent)
        {
            _subscriberComponent = subscriberComponent;
        }
        
        public IObservable<KeyValuePair<TKey,TValue>> GetUpdates(TKey key)
        {
            var subject = new Subject<KeyValuePair<TKey,TValue>>();
            var observable = subject
                .CreateObservable(() => _subscriberComponent.Subscribe(key),
                                  () =>
                                      {
                                          ISubject<KeyValuePair<TKey, TValue>> subjectToRemove;
                                          IObservable<KeyValuePair<TKey, TValue>> observableToRemove;
                                          _subscriberComponent.UnSubscribe(key);
                                          _subjects.TryRemove(key, out subjectToRemove);
                                          _observables.TryRemove(key, out observableToRemove);
                                      })
                .Publish()
                .RefCount();

            _subjects.AddOrUpdate(key, subject, (_, entry) => entry);
            _observables.AddOrUpdate(key, observable, (_, entry) => entry);

            _subscriberComponent.Subscribe(key);
            _subscriberComponent.Updates.Subscribe(update => _subjects[key].OnNext(update));

            return observable.StartWith(_subscriberComponent.GetIntialValue(key));
        }

        public IObservable<KeyValuePair<TKey, TValue>> GetUpdates(IEnumerable<TKey> keys)
        {
            return keys
                .Select(GetUpdates)
                .Aggregate((a, b) => a.Merge(b));
        }

        public IEnumerable<TKey> SubscriptionKeys
        {
            get { return _subjects.Keys; }
        }

        public void Dispose()
        {
            _subscriberComponent.Dispose();
        }
    }
}