using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Extensions.DependencyInjection;
using System;
using Skclusive.Text.Json;
using Skclusive.Reactive.Flow;

namespace Skclusive.Blazor.StateTree.App.State
{
    public static class StateTreeStateExtension
    {
        public static void TryAddStateTreeStateServices(this IServiceCollection services)
        {
            services.TryAddReactiveFlowServices();

            services.TryAddScoped<ICounterObservable>((_) => AppTypes.CounterType.Create(new Counter()));

            services.TryAddFlowEffect<CountIncrementEffect>();

            services.TryAddFlowEpic<CountIncrementEpic>();

            services.TryAddJsonTypeConverter<ICounter, Counter>();
        }
    }
}
