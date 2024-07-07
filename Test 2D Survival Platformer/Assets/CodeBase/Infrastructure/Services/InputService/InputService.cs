using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.InputService
{
    public class InputService : IInputService, ITickable
    {
        private const string HorizontalAxisName = "Horizontal";
        public ReactiveProperty<float> HorizontalMoveInput { get; } = new();

        public void Tick()
        {
            float horizontalInput = Input.GetAxis(HorizontalAxisName);
            
            if(horizontalInput != 0)
                HorizontalMoveInput.SetValueAndForceNotify(horizontalInput);
            else
                HorizontalMoveInput.Value = horizontalInput;
        }
    }
}