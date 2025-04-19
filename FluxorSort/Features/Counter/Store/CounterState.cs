using Fluxor;

namespace FluxorSort.Features.Counter.Store;


[FeatureState(Name = nameof(CounterState))]
public sealed record CounterState
{
    public int Count { get; init; }

    private CounterState() {}
}
