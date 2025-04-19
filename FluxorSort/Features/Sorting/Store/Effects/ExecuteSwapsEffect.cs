using Fluxor;
using FluxorSort.Features.Sorting.Sorters;
using FluxorSort.Features.Sorting.Store.Actions;
using FluxorSort.Features.Sorting.Types;

namespace FluxorSort.Features.Sorting.Store.Effects;

public class ExecuteSwapsEffect(IState<SortingState> state)
{

    //[EffectMethod]
    //public async Task HandleExecuteSwapsAction(ExecuteSwapsAction swapsAction, IDispatcher dispatcher)
    //{
    //    if (state.Value.IsSorting is false || swapsAction.Swaps.Count is 0)
    //    {
    //        dispatcher.Dispatch(new PauseSortingAction());
    //        return;
    //    }

    //    var swap = swapsAction.Swaps.Dequeue();
    //    dispatcher.Dispatch(swap);

    //    await Task.Delay(1); //Delay to ensure reducers have time to update state for each swap

    //    dispatcher.Dispatch(swapsAction);
    //}
    [EffectMethod]
    public async Task HandleExecuteSwapsAction(ExecuteSwapsAction swapsAction, IDispatcher dispatcher)
    {
        // Nếu đang không sorting hoặc hết swap actions thì dừng
        if (state.Value.IsSorting is false || swapsAction.Swaps.Count == 0)
        {
            dispatcher.Dispatch(new PauseSortingAction());
            return;
        }

        // Lấy swap tiếp theo và dispatch nó
        var swap = swapsAction.Swaps.Dequeue();
        dispatcher.Dispatch(swap);

        // Delay một chút để UI có thể render lại
        await Task.Delay(100); // Tăng thời gian delay để dễ quan sát hơn

        // Nếu còn swaps, tiếp tục dispatch ExecuteSwapsAction
        if (swapsAction.Swaps.Count > 0)
        {
            dispatcher.Dispatch(new ExecuteSwapsAction(swapsAction.Swaps));
        }
        else
        {
            // Đảm bảo gửi PauseSortingAction khi hoàn thành
            dispatcher.Dispatch(new PauseSortingAction());
        }
    }


}
