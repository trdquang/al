using Fluxor;
using FluxorSort.Features.Sorting.Types;

namespace FluxorSort.Features.Sorting.Store;


[FeatureState(Name = nameof(SortingState))]
public sealed record SortingState
{
    private SortingState() { }

    public bool IsSorting { get; init; }

    public List<int> Array { get; init; } = Enumerable.Range(1,50).ToList();

    public SorterType SorterType { get; init; } = SorterType.None;
}
