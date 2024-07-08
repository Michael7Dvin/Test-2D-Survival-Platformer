using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.InputService
{
    public class InputService : IInputService, ITickable
    {
        private const string HorizontalAxisName = "Horizontal";
        private readonly ReactiveProperty<float> _horizontalMoveInput = new();

        public IReadOnlyReactiveProperty<float> HorizontalMoveInput => _horizontalMoveInput;

        public void Tick()
        {
            float horizontalInput = Input.GetAxis(HorizontalAxisName);
            
            if(horizontalInput != 0)
                _horizontalMoveInput.SetValueAndForceNotify(horizontalInput);
            else
                _horizontalMoveInput.Value = horizontalInput;
        }
    }
}