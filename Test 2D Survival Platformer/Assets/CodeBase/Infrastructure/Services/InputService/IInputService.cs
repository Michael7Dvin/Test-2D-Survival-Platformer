using UniRx;

namespace CodeBase.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        IReadOnlyReactiveProperty<float> HorizontalMoveInput { get; }
    }
}