using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Extensions.DependencyInjection;
using System;
using Skclusive.Reactive.Flow;

namespace Skclusive.Blazor.StateTree.App.State
{
    public static class StateTreeStateExtension
    {
        public static void TryAddStateTreeStateServices(this IServiceCollection services)
        {
            services.TryAddReactiveFlowServices();

            services.TryAddScoped<ICounterObservable>((_) => AppTypes.CounterType.Create(new Counter()));

            services.TryAddEnumerable(ServiceDescriptor.Scoped<IEffect, CountIncrementEffect>());

            services.TryAddEnumerable(ServiceDescriptor.Scoped<IEpic, CountIncrementEpic>());
        }
    }
}
