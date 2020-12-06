using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Extensions.DependencyInjection;
using System;
using Skclusive.Text.Json;
using Skclusive.Reactive.Flow;
using System.Reactive.Concurrency;

namespace Skclusive.Reactive.App.State
{
    public static class ReactiveStateExtension
    {
        public static void TryAddReactiveStateServices(this IServiceCollection services, IScheduler scheduler)
        {
            services.TryAddReactiveFlowServices(scheduler);

            services.TryAddScoped<ICounterObservable>((_) => AppTypes.CounterType.Create(new Counter()));

            services.TryAddFlowEffect<CountIncrementEffect>();

            services.TryAddFlowEpic<CountIncrementEpic>();

            services.TryAddJsonTypeConverter<ICounter, Counter>();
        }
    }
}
