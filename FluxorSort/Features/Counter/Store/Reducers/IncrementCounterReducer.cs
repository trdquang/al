using Fluxor;
using FluxorSort.Features.Counter.Store.Actions;

namespace FluxorSort.Features.Counter.Store.Reducers;

public static class IncrementCounterReducer
{
    [ReducerMethod]
    public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
        state with { Count = state.Count + action.Increment };

}
