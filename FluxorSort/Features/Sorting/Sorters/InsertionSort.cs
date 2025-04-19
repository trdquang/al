using FluxorSort.Features.Sorting.Store.Actions;

namespace FluxorSort.Features.Sorting.Sorters;

public static class InsertionSort
{
    public static Queue<SwapAction> Sort(List<int> array)
    {
        var swaps = new Queue<SwapAction>();
        var inputArray = new List<int>(array);
        for (var i = 0; i < inputArray.Count - 1; i++)
        {
            for (var j = i + 1; j > 0; j--)
            {
                if (inputArray[j - 1] <= inputArray[j]) continue;

                (inputArray[j - 1], inputArray[j]) = (inputArray[j], inputArray[j - 1]);
                swaps.Enqueue(new SwapAction(j-1, j));
            }
        }

        return swaps;
    }
}
