using FluxorSort.Features.Sorting.Store.Actions;

namespace FluxorSort.Features.Sorting.Sorters;

public static class MergeSort
{
    public static Queue<SwapAction> Sort(List<int> array)
    {
        var swaps = new Queue<SwapAction>();
        var tempArray = new List<int>(array);
        var n = tempArray.Count;

        // Tạo một bản sao của mảng ban đầu để theo dõi các thay đổi
        var workingArray = new List<int>(array);

        // Thực hiện merge sort và thu thập các hoán đổi
        MergeSortWithSwaps(workingArray, 0, n - 1, swaps, tempArray);

        return swaps;
    }

    private static void MergeSortWithSwaps(List<int> array, int left, int right, Queue<SwapAction> swaps, List<int> tempArray)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            // Sắp xếp nửa đầu và nửa sau
            MergeSortWithSwaps(array, left, middle, swaps, tempArray);
            MergeSortWithSwaps(array, middle + 1, right, swaps, tempArray);

            // Trộn hai nửa đã sắp xếp và tạo các SwapAction
            MergeWithSwaps(array, left, middle, right, swaps, tempArray);
        }
    }

    private static void MergeWithSwaps(List<int> array, int left, int middle, int right, Queue<SwapAction> swaps, List<int> tempArray)
    {
        // Sao chép dữ liệu vào mảng tạm thời
        for (int i = left; i <= right; i++)
        {
            tempArray[i] = array[i];
        }

        int i1 = left;      // Chỉ số cho nửa đầu tiên
        int i2 = middle + 1; // Chỉ số cho nửa thứ hai
        int current = left;  // Chỉ số hiện tại trong mảng kết quả

        // Trộn hai mảng con đã sắp xếp
        while (i1 <= middle && i2 <= right)
        {
            if (tempArray[i1] <= tempArray[i2])
            {
                // Nếu phần tử từ mảng con bên trái nhỏ hơn hoặc bằng
                if (array[current] != tempArray[i1])
                {
                    // Tìm vị trí của phần tử cần đặt vào vị trí hiện tại
                    int sourceIndex = -1;
                    for (int i = current; i <= right; i++)
                    {
                        if (array[i] == tempArray[i1])
                        {
                            sourceIndex = i;
                            break;
                        }
                    }

                    if (sourceIndex != -1 && sourceIndex != current)
                    {
                        // Hoán đổi phần tử
                        (array[current], array[sourceIndex]) = (array[sourceIndex], array[current]);
                        swaps.Enqueue(new SwapAction(current, sourceIndex));
                    }
                    else
                    {
                        array[current] = tempArray[i1];
                    }
                }
                i1++;
            }
            else
            {
                // Nếu phần tử từ mảng con bên phải nhỏ hơn
                if (array[current] != tempArray[i2])
                {
                    // Tìm vị trí của phần tử cần đặt vào vị trí hiện tại
                    int sourceIndex = -1;
                    for (int i = current; i <= right; i++)
                    {
                        if (array[i] == tempArray[i2])
                        {
                            sourceIndex = i;
                            break;
                        }
                    }

                    if (sourceIndex != -1 && sourceIndex != current)
                    {
                        // Hoán đổi phần tử
                        (array[current], array[sourceIndex]) = (array[sourceIndex], array[current]);
                        swaps.Enqueue(new SwapAction(current, sourceIndex));
                    }
                    else
                    {
                        array[current] = tempArray[i2];
                    }
                }
                i2++;
            }
            current++;
        }

        // Sao chép các phần tử còn lại của mảng trái (nếu có)
        while (i1 <= middle)
        {
            if (array[current] != tempArray[i1])
            {
                // Tìm vị trí của phần tử cần đặt vào vị trí hiện tại
                int sourceIndex = -1;
                for (int i = current; i <= right; i++)
                {
                    if (array[i] == tempArray[i1])
                    {
                        sourceIndex = i;
                        break;
                    }
                }

                if (sourceIndex != -1 && sourceIndex != current)
                {
                    // Hoán đổi phần tử
                    (array[current], array[sourceIndex]) = (array[sourceIndex], array[current]);
                    swaps.Enqueue(new SwapAction(current, sourceIndex));
                }
                else
                {
                    array[current] = tempArray[i1];
                }
            }
            i1++;
            current++;
        }

        // Sao chép các phần tử còn lại của mảng phải (nếu có)
        while (i2 <= right)
        {
            if (array[current] != tempArray[i2])
            {
                // Tìm vị trí của phần tử cần đặt vào vị trí hiện tại
                int sourceIndex = -1;
                for (int i = current; i <= right; i++)
                {
                    if (array[i] == tempArray[i2])
                    {
                        sourceIndex = i;
                        break;
                    }
                }

                if (sourceIndex != -1 && sourceIndex != current)
                {
                    // Hoán đổi phần tử
                    (array[current], array[sourceIndex]) = (array[sourceIndex], array[current]);
                    swaps.Enqueue(new SwapAction(current, sourceIndex));
                }
                else
                {
                    array[current] = tempArray[i2];
                }
            }
            i2++;
            current++;
        }
    }
}
