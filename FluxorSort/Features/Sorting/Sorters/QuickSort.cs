using FluxorSort.Features.Sorting.Store.Actions;

namespace FluxorSort.Features.Sorting.Sorters;

public static class QuickSort
{
    public static Queue<SwapAction> Sort(List<int> array)
    {
        var swaps = new Queue<SwapAction>();
        var inputArray = new List<int>(array);

        PerformQuickSort(inputArray.ToArray(), 0, inputArray.Count - 1, swaps);

        return swaps;
    }

    private static void PerformQuickSort(int[] arr, int left, int right, Queue<SwapAction> swaps)
    {
        // Check if there are elements to sort
        if (left >= right)
            return;

        // Find the pivot index
        var pivot = Partition(arr, left, right, swaps);

        // Recursively sort elements on the left and right of the pivot
        if (pivot > 1) {
            PerformQuickSort(arr, left, pivot - 1, swaps);
        }

        if (pivot + 1 < right) {
            PerformQuickSort(arr, pivot + 1, right, swaps);
        }
    }

    private static int Partition(int[] arr, int left, int right, Queue<SwapAction> swaps)
    {
        // Select the pivot element
        var pivot = arr[left];

        // Continue until left and right pointers meet
        while (true)
        {
            // Move left pointer until a value greater than or equal to pivot is found
            while (arr[left] < pivot)
            {
                left++;
            }

            // Move right pointer until a value less than or equal to pivot is found
            while (arr[right] > pivot)
            {
                right--;
            }

            // If left pointer is still smaller than right pointer, swap elements
            if (left < right)
            {
                if (arr[left] == arr[right])
                    return right;

                (arr[left], arr[right]) = (arr[right], arr[left]);
                swaps.Enqueue( new SwapAction(left, right));
            }
            else
            {
                // Return the right pointer indicating the partitioning position
                return right;
            }
        }
    }
}
