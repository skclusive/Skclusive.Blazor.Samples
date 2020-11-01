using Skclusive.Reactive.Flow;

namespace Skclusive.Blazor.StateTree.App.State
{
    public class CountIncrementEffect : IEffect
    {
        private ICounterObservable Counter { get; }

        public CountIncrementEffect(ICounterObservable counter)
        {
            Counter = counter;
        }

        public void Run(IAction action)
        {
            switch (action)
            {
                case BeginCountIncrementAction _:
                {
                    Counter.Begin();
                    return;
                }
                case ContinueCountIncrementAction _:
                {
                    Counter.Continue();
                    return;
                }
                case EndCountIncrementAction _:
                {
                    Counter.End();
                    return;
                }
            }
        }
    }
}
