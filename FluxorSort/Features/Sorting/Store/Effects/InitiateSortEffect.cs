using Fluxor;
using FluxorSort.Features.Sorting.Sorters;
using FluxorSort.Features.Sorting.Store.Actions;
using FluxorSort.Features.Sorting.Types;

namespace FluxorSort.Features.Sorting.Store.Effects;

public class InitiateSortEffect(IState<SortingState> state)
{
    [EffectMethod]
    public static Task HandleStartSortAction(InitiateSortAction action, IDispatcher dispatcher)
    {
        if (action.SorterType is SorterType.None)
        {
            dispatcher.Dispatch(new ResetAction());
            return Task.CompletedTask;
        }

        var swaps = action.SorterType switch
        {
            SorterType.InsertionSort => InsertionSort.Sort(action.Array),
            SorterType.QuickSort => QuickSort.Sort(action.Array),
            SorterType.BubbleSort => BubbleSort.Sort(action.Array),
            SorterType.SelectionSort => SelectionSort.Sort(action.Array),
            SorterType.MergeSort => MergeSort.Sort(action.Array),
            SorterType.HeapSort => HeapSort.Sort(action.Array),
            _ => new Queue<SwapAction>()
        };

        dispatcher.Dispatch(new ExecuteSwapsAction(swaps));
        return Task.CompletedTask;
    }
}