using System;
using UniRx;

namespace CodeBase.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        IReadOnlyReactiveProperty<float> HorizontalMoveInput { get; }
        IObservable<Unit> Vanish { get; }
    }
}