using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Extensions.DependencyInjection;
using System;
using Skclusive.Text.Json;
using Skclusive.Reactive.Flow;
using System.Reactive.Concurrency;

// https://stackoverflow.com/questions/64749385/predefined-type-system-runtime-compilerservices-isexternalinit-is-not-defined
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}

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
