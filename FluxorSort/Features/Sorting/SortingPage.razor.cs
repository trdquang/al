using Fluxor;
using FluxorSort.Features.Sorting.Store;
using FluxorSort.Features.Sorting.Store.Actions;
using Microsoft.AspNetCore.Components;

namespace FluxorSort.Features.Sorting;

public partial class SortingPage
{
    [Inject]
    private IState<SortingState>? SorterState { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    private void Sort()
    {
        Dispatcher.Dispatch(new InitiateSortAction(SorterState!.Value.SorterType, SorterState!.Value.Array));
    }

    private void Shuffle()
    {
        Dispatcher.Dispatch(new ShuffleAction());
    }

    private void Pause()
    {
        Dispatcher.Dispatch(new PauseSortingAction());
    }
}
