using Fluxor;
using FluxorSort.Features.Counter.Store;
using FluxorSort.Features.Counter.Store.Actions;
using Microsoft.AspNetCore.Components;

namespace FluxorSort.Features.Counter;

public partial class CounterPage
{
    [Inject]
    private IState<CounterState>? CounterState { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    private void IncrementCount(int increment)
    {
        Dispatcher.Dispatch(new IncrementCounterAction(increment));
    }
}
