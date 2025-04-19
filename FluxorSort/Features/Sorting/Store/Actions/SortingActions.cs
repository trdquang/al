using FluxorSort.Features.Sorting.Types;

namespace FluxorSort.Features.Sorting.Store.Actions;


public sealed record ResetAction;
public sealed record ShuffleAction;
public sealed record PauseSortingAction;
public sealed record UpdateSorterTypeAction(SorterType SorterType);
public sealed record InitiateSortAction(SorterType SorterType, List<int> Array);
public sealed record ExecuteSwapsAction(Queue<SwapAction> Swaps);
public sealed record SwapAction(int Index1, int Index2);
