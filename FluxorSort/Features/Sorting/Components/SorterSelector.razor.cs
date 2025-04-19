using Fluxor;
using FluxorSort.Features.Sorting.Store;
using FluxorSort.Features.Sorting.Store.Actions;
using FluxorSort.Features.Sorting.Types;
using Microsoft.AspNetCore.Components;

namespace FluxorSort.Features.Sorting.Components;

public partial class SorterSelector
{
    [Inject]
    private IState<SortingState>? SorterState { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    private void UpdateSorterType(ChangeEventArgs e)
    {
        if (Enum.TryParse(typeof(SorterType), e.Value?.ToString(), out var result))
        {
            Dispatcher.Dispatch(new UpdateSorterTypeAction((SorterType)result));
        }

    }

}
