using System;
using Skclusive.Reactive.Flow;

namespace Skclusive.Reactive.App.State
{
    public class CountIncrementAction : IAction
    {
        public int Total { get; init; }
    }

    public class BeginCountIncrementAction : IAction
    {
    }

    public class ContinueCountIncrementAction : IAction
    {
    }

    public class CancelCountIncrementAction : IAction
    {
    }

    public class EndCountIncrementAction : IAction
    {
    }

    public class ErrorCountIncrementAction : IAction
    {
        public Exception Exception { get; init; }
    }
}
