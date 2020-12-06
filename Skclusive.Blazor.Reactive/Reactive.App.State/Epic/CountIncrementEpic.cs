using System;
using System.Reactive.Linq;
using Skclusive.Reactive.Flow;

namespace Skclusive.Reactive.App.State
{
    public class CountIncrementEpic : IEpic
    {
        public IObservable<IAction> Configure(IObservable<IAction> actions)
        {
            return actions.OfType<CountIncrementAction>()
             .SelectMany
             (action =>
                Observable.Return(new BeginCountIncrementAction())
                .Concat
                (
                    GetCount(action.Total)
                    .TakeUntil(actions.OfType<CancelCountIncrementAction>())
                    .Select(store => new ContinueCountIncrementAction())
                    .Catch((Exception exception) => Observable.Return<IAction>
                    (
                        new ErrorCountIncrementAction { Exception = exception }
                    ))
                )
                .Concat(Observable.Return<IAction>(new EndCountIncrementAction()))
             );
        }

        private static IObservable<long> GetCount(int total)
        {
            return Observable.Interval(TimeSpan.FromSeconds(1)).Take(total);
        }
    }
}
