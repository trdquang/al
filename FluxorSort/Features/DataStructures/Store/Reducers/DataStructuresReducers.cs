using Fluxor;
using Fluxor.Blazor.Web.Middlewares.Routing;
using FluxorSort.Features.DataStructures.Store.Actions;
using FluxorSort.Features.DataStructures.Types;
using Microsoft.VisualBasic;

namespace FluxorSort.Features.DataStructures.Store.Reducers;

public static class DataStructuresReducers
{
    [ReducerMethod]
    public static DataStructuresState ReduceChangeDataStructureTypeAction(
        DataStructuresState state, ChangeDataStructureTypeAction action)
    {
        return state with
        {
            CurrentType = action.Type,
            Elements = new List<int>(),
            OperationHistory = new List<string>(),
            Message = $"Đã chuyển sang {action.Type}"
        };
    }

    // Stack Reducers

    [ReducerMethod]
    public static DataStructuresState ReducePushAction(DataStructuresState state, PushAction action)
    {
        var newElements = new List<int>(state.Elements);
        newElements.Add(action.Value);

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Push: {action.Value}");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = action.Value,
            CurrentPosition = newElements.Count - 1,
            Message = $"Đã thêm {action.Value} vào Stack"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReducePopAction(DataStructuresState state, PopAction action)
    {
        if (state.Elements.Count == 0)
        {
            return state with
            {
                Message = "Stack rỗng, không thể Pop"
            };
        }

        var newElements = new List<int>(state.Elements);
        var poppedValue = newElements[^1];
        newElements.RemoveAt(newElements.Count - 1);

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Pop: {poppedValue}");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = poppedValue,
            CurrentPosition = null,
            Message = $"Đã lấy {poppedValue} ra khỏi Stack"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReducePeekStackAction(DataStructuresState state, PeekStackAction action)
    {
        if (state.Elements.Count == 0)
        {
            return state with
            {
                Message = "Stack rỗng, không thể Peek"
            };
        }

        var peekedValue = state.Elements[^1];

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Peek: {peekedValue}");

        return state with
        {
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = peekedValue,
            CurrentPosition = state.Elements.Count - 1,
            Message = $"Phần tử đầu Stack: {peekedValue}"
        };
    }

    // Queue Reducers

    [ReducerMethod]
    public static DataStructuresState ReduceEnqueueAction(DataStructuresState state, EnqueueAction action)
    {
        var newElements = new List<int>(state.Elements);
        newElements.Add(action.Value);

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Enqueue: {action.Value}");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = action.Value,
            CurrentPosition = newElements.Count - 1,
            Message = $"Đã thêm {action.Value} vào Queue"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReduceDequeueAction(DataStructuresState state, DequeueAction action)
    {
        if (state.Elements.Count == 0)
        {
            return state with
            {
                Message = "Queue rỗng, không thể Dequeue"
            };
        }

        var newElements = new List<int>(state.Elements);
        var dequeuedValue = newElements[0];
        newElements.RemoveAt(0);

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Dequeue: {dequeuedValue}");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = dequeuedValue,
            CurrentPosition = null,
            Message = $"Đã lấy {dequeuedValue} ra khỏi Queue"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReducePeekQueueAction(DataStructuresState state, PeekQueueAction action)
    {
        if (state.Elements.Count == 0)
        {
            return state with
            {
                Message = "Queue rỗng, không thể Peek"
            };
        }

        var peekedValue = state.Elements[0];

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Peek: {peekedValue}");

        return state with
        {
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = peekedValue,
            CurrentPosition = 0,
            Message = $"Phần tử đầu Queue: {peekedValue}"
        };
    }

    // List Reducers

    [ReducerMethod]
    public static DataStructuresState ReduceAddAction(DataStructuresState state, AddAction action)
    {
        var newElements = new List<int>(state.Elements);
        newElements.Add(action.Value);

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Add: {action.Value}");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = action.Value,
            CurrentPosition = newElements.Count - 1,
            Message = $"Đã thêm {action.Value} vào List"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReduceInsertAction(DataStructuresState state, InsertAction action)
    {
        if (action.Index < 0 || action.Index > state.Elements.Count)
        {
            return state with
            {
                Message = $"Vị trí {action.Index} không hợp lệ"
            };
        }

        var newElements = new List<int>(state.Elements);
        newElements.Insert(action.Index, action.Value);

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Insert: {action.Value} tại vị trí {action.Index}");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = action.Value,
            CurrentPosition = action.Index,
            Message = $"Đã chèn {action.Value} vào vị trí {action.Index}"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReduceRemoveAction(DataStructuresState state, RemoveAction action)
    {
        var index = state.Elements.IndexOf(action.Value);
        if (index == -1)
        {
            return state with
            {
                Message = $"Không tìm thấy phần tử {action.Value} trong List"
            };
        }

        var newElements = new List<int>(state.Elements);
        newElements.Remove(action.Value);

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Remove: {action.Value}");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = action.Value,
            CurrentPosition = null,
            Message = $"Đã xóa {action.Value} khỏi List"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReduceRemoveAtAction(DataStructuresState state, RemoveAtAction action)
    {
        if (action.Index < 0 || action.Index >= state.Elements.Count)
        {
            return state with
            {
                Message = $"Vị trí {action.Index} không hợp lệ"
            };
        }

        var newElements = new List<int>(state.Elements);
        var removedValue = newElements[action.Index];
        newElements.RemoveAt(action.Index);

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"RemoveAt: vị trí {action.Index} (giá trị {removedValue})");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = true,
            CurrentElement = removedValue,
            CurrentPosition = null,
            Message = $"Đã xóa phần tử tại vị trí {action.Index} (giá trị {removedValue})"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReduceClearAction(DataStructuresState state, ClearAction action)
    {
        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add("Clear");

        return state with
        {
            Elements = new List<int>(),
            OperationHistory = newHistory,
            IsOperating = false,
            CurrentElement = null,
            CurrentPosition = null,
            Message = "Đã xóa tất cả phần tử"
        };
    }

    // Common Reducers

    [ReducerMethod]
    public static DataStructuresState ReduceResetDataStructureAction(
        DataStructuresState state, ResetDataStructureAction action)
    {
        return state with
        {
            Elements = new List<int>(),
            OperationHistory = new List<string>(),
            IsOperating = false,
            CurrentElement = null,
            CurrentPosition = null,
            Message = "Đã reset cấu trúc dữ liệu"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReduceGenerateRandomDataAction(
        DataStructuresState state, GenerateRandomDataAction action)
    {
        var random = new Random();
        var newElements = new List<int>();

        for (int i = 0; i < action.Count; i++)
        {
            newElements.Add(random.Next(1, 100));
        }

        var newHistory = new List<string>(state.OperationHistory);
        newHistory.Add($"Tạo ngẫu nhiên {action.Count} phần tử");

        return state with
        {
            Elements = newElements,
            OperationHistory = newHistory,
            IsOperating = false,
            CurrentElement = null,
            CurrentPosition = null,
            Message = $"Đã tạo {action.Count} phần tử ngẫu nhiên"
        };
    }

    [ReducerMethod]
    public static DataStructuresState ReduceCompleteOperationAction(
        DataStructuresState state, CompleteOperationAction action)
    {
        return state with
        {
            IsOperating = false,
            CurrentElement = null,
            CurrentPosition = null
        };
    }
}