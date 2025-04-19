using FluxorSort.Features.Sorting.Store.Actions;

namespace FluxorSort.Features.Sorting.Sorters;

public static class SelectionSort
{
    public static Queue<SwapAction> Sort(List<int> array)
    {
        var swaps = new Queue<SwapAction>();
        var inputArray = new List<int>(array);
        int n = inputArray.Count;

        for (int i = 0; i < n - 1; i++)
        {
            // Tìm phần tử nhỏ nhất trong mảng chưa sắp xếp
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (inputArray[j] < inputArray[minIndex])
                {
                    minIndex = j;
                }
            }

            // Nếu tìm thấy phần tử nhỏ nhất khác với phần tử hiện tại
            if (minIndex != i)
            {
                // Hoán đổi phần tử nhỏ nhất với phần tử đầu tiên
                (inputArray[i], inputArray[minIndex]) = (inputArray[minIndex], inputArray[i]);
                swaps.Enqueue(new SwapAction(i, minIndex));
            }
        }

        return swaps;
    }
}