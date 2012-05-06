using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive;

namespace Provider
{
    public class TimedSubscriber<TKey,TValue>
            : ISubscriber<TKey, TValue> where TKey : IKey where TValue : IValue
    {
        private Dictionary<TKey, ISubject<TValue>>
            _subscriptionKeys = new Dictionary<TKey, ISubject<TValue>>();
        private IRequester<TKey,TValue> _requester;
        public IEnumerable<TKey> SubscriptionKeys
        {
            get { return _subscriptionKeys.Keys; }
        }

        public TimedSubscriber(TimeSpan sampleRate, IRequester<TKey,TValue> requester)
        {
            _requester = requester;
            Timer sampleTimer = new Timer(sampleRate.TotalMilliseconds);
            Observable
                .FromEventPattern<ElapsedEventHandler, ElapsedEventArgs>
                    (h => sampleTimer.Elapsed += h, h => sampleTimer.Elapsed -= h)
                .Subscribe(e =>
                    _subscriptionKeys
                    .ToList()
                    .ForEach(key =>
                        _subscriptionKeys[key.Key]
                        .OnNext(GetEntry(key.Key))));

            sampleTimer.Start();
        }

        public IObservable<TValue> GetUpdates(TKey key)
        {
            var subject = new Subject<TValue>();
            _subscriptionKeys.Add(key, subject);
            return subject;
        }

        public TValue GetEntry(TKey key)
        {
            return _requester.GetValue(key);
        }

        public IEnumerable<TValue> GetEntries(IEnumerable<TKey> keys)
        {
            return keys.Select(key => GetEntry(key));
        }

        public void UnSubscribe(TKey key)
        {
            _subscriptionKeys.Remove(key);
        }
    }
}
