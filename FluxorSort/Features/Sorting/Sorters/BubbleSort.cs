using FluxorSort.Features.Sorting.Store.Actions;

namespace FluxorSort.Features.Sorting.Sorters;

public static class BubbleSort
{
    public static Queue<SwapAction> Sort(List<int> array)
    {
        var swaps = new Queue<SwapAction>();
        var inputArray = new List<int>(array);

        for (int i = 0; i < inputArray.Count - 1; i++)
        {
            for (int j = 0; j < inputArray.Count - i - 1; j++)
            {
                if (inputArray[j] > inputArray[j + 1])
                {
                    // Hoán đổi phần tử
                    (inputArray[j], inputArray[j + 1]) = (inputArray[j + 1], inputArray[j]);
                    swaps.Enqueue(new SwapAction(j, j + 1));
                }
            }
        }

        return swaps;
    }
}