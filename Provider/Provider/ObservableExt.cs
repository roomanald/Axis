using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Provider
{
    public static class ObservableExt
    {
        public static IObservable<KeyValuePair<TKey, TValue>> CreateObservable<TKey, TValue>(
            this IObservable<KeyValuePair<TKey, TValue>> source,
            Action onInitialise,
            Action onDispose)
        {
            return Observable.Create<KeyValuePair<TKey, TValue>>(
                observer =>
                    {
                        onInitialise();

                        var disp = source.Subscribe(observer);

                        return Disposable.Create(() =>
                                                     {
                                                         disp.Dispose();

                                                         onDispose();
                                                     });
                    });
        }
    }
}