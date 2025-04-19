using Microsoft.AspNetCore.Components;

namespace FluxorSort.Features.Sorting.Components;

public partial class SortingArray
{
    [Parameter]
    public List<int> Array { get; set; }
}
