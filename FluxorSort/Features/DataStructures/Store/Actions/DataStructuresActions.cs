using FluxorSort.Features.DataStructures.Types;

namespace FluxorSort.Features.DataStructures.Store.Actions;

// Thay đổi loại cấu trúc dữ liệu
public sealed record ChangeDataStructureTypeAction(DataStructureType Type);

// Các thao tác trên Stack
public sealed record PushAction(int Value);
public sealed record PopAction;
public sealed record PeekStackAction;

// Các thao tác trên Queue
public sealed record EnqueueAction(int Value);
public sealed record DequeueAction;
public sealed record PeekQueueAction;

// Các thao tác trên List
public sealed record AddAction(int Value);
public sealed record InsertAction(int Value, int Index);
public sealed record RemoveAction(int Value);
public sealed record RemoveAtAction(int Index);
public sealed record ClearAction;

// Các thao tác chung
public sealed record ResetDataStructureAction;
public sealed record GenerateRandomDataAction(int Count);
public sealed record CompleteOperationAction;