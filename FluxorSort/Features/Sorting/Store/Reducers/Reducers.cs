using Fluxor;
using FluxorSort.Features.Sorting.Store.Actions;

namespace FluxorSort.Features.Sorting.Store.Reducers;

public class Reducers
{

    [ReducerMethod]
    public static SortingState ReduceSwapAction(SortingState state, SwapAction action)
    {
        var array = state.Array;
        (array[action.Index1], array[action.Index2]) = (array[action.Index2], array[action.Index1]);
        return state with { Array = array };
    }

    [ReducerMethod]
    public static SortingState ReduceUpdateSorterTypeAction(SortingState state, UpdateSorterTypeAction action) =>
        state with { SorterType = action.SorterType };


    [ReducerMethod(typeof(InitiateSortAction))]
    public static SortingState ReduceStartSortAction(SortingState state) =>
        state with { IsSorting = true };

    [ReducerMethod(typeof(ResetAction))]
    public static SortingState ReduceResetAction(SortingState state) =>
        state with { IsSorting = false, Array = state.Array.OrderBy(x => x).ToList() };

    [ReducerMethod(typeof(ShuffleAction))]
    public static SortingState ReduceShuffleAction(SortingState state)
    {
        var r = new Random();
        return state with { Array = state.Array.OrderBy(_ => r.Next()).ToList() };
    }

    [ReducerMethod(typeof(PauseSortingAction))]
    public static SortingState ReducePauseSortingAction(SortingState state) =>
        state with { IsSorting = false };
}
