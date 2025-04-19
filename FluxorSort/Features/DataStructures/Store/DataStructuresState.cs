using Fluxor;
using FluxorSort.Features.DataStructures.Types;

namespace FluxorSort.Features.DataStructures.Store;

[FeatureState(Name = nameof(DataStructuresState))]
public sealed record DataStructuresState
{
    private DataStructuresState() { }

    public DataStructureType CurrentType { get; init; } = DataStructureType.Stack;

    // Các phần tử trong cấu trúc dữ liệu
    public List<int> Elements { get; init; } = new();

    // Lịch sử các thao tác
    public List<string> OperationHistory { get; init; } = new();

    // Trạng thái đang thực hiện thao tác
    public bool IsOperating { get; init; } = false;

    // Phần tử đang được thao tác (để hiển thị animation)
    public int? CurrentElement { get; init; } = null;

    // Vị trí đang được thao tác (để hiển thị animation)
    public int? CurrentPosition { get; init; } = null;

    // Thông báo
    public string? Message { get; init; } = null;
}