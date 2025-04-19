using Fluxor;
using FluxorSort.Features.DataStructures.Store.Actions;

namespace FluxorSort.Features.DataStructures.Store.Effects;

public class DataStructuresEffects
{
    [EffectMethod]
    public async Task HandleOperationCompletion(
        PushAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000); // Delay để hiển thị animation
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        PopAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        PeekStackAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        EnqueueAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        DequeueAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        PeekQueueAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        AddAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        InsertAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        RemoveAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }

    [EffectMethod]
    public async Task HandleOperationCompletion(
        RemoveAtAction action,
        IDispatcher dispatcher)
    {
        await Task.Delay(1000);
        dispatcher.Dispatch(new CompleteOperationAction());
    }
}