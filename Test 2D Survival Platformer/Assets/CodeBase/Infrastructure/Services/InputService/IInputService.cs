using UniRx;

namespace CodeBase.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        ReactiveProperty<float> HorizontalMoveInput { get; }
    }
}