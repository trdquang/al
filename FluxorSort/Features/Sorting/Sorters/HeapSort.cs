using FluxorSort.Features.Sorting.Store.Actions;

namespace FluxorSort.Features.Sorting.Sorters;

public static class HeapSort
{
    public static Queue<SwapAction> Sort(List<int> array)
    {
        var swaps = new Queue<SwapAction>();
        var inputArray = new List<int>(array);
        int n = inputArray.Count;

        // Xây dựng heap (sắp xếp lại mảng)
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(inputArray, n, i, swaps);
        }

        // Trích xuất từng phần tử từ heap
        for (int i = n - 1; i > 0; i--)
        {
            // Di chuyển root hiện tại đến cuối
            (inputArray[0], inputArray[i]) = (inputArray[i], inputArray[0]);
            swaps.Enqueue(new SwapAction(0, i));

            // Gọi max heapify trên heap đã giảm kích thước
            Heapify(inputArray, i, 0, swaps);
        }

        return swaps;
    }

    // Để vun đống một cây con có gốc tại node i
    private static void Heapify(List<int> arr, int n, int i, Queue<SwapAction> swaps)
    {
        int largest = i; // Khởi tạo largest là root
        int left = 2 * i + 1; // left = 2*i + 1
        int right = 2 * i + 2; // right = 2*i + 2

        // Nếu con trái lớn hơn root
        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }

        // Nếu con phải lớn hơn largest hiện tại
        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }

        // Nếu largest không phải là root
        if (largest != i)
        {
            (arr[i], arr[largest]) = (arr[largest], arr[i]);
            swaps.Enqueue(new SwapAction(i, largest));

            // Đệ quy vun đống cây con bị ảnh hưởng
            Heapify(arr, n, largest, swaps);
        }
    }
}