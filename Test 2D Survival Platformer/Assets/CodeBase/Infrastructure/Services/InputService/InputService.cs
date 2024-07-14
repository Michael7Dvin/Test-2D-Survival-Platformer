using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.InputService
{
    public class InputService : IInputService, ITickable
    {
        private const string HorizontalAxisName = "Horizontal";
        private readonly ReactiveProperty<float> _horizontalMoveInput = new();
        private readonly Subject<Unit> _vanish = new();
        
        public IReadOnlyReactiveProperty<float> HorizontalMoveInput => _horizontalMoveInput;
        public IObservable<Unit> Vanish => _vanish;

        public void Tick()
        {
            float horizontalInput = Input.GetAxis(HorizontalAxisName);
            
            if (horizontalInput != 0)
                _horizontalMoveInput.SetValueAndForceNotify(horizontalInput);
            else
                _horizontalMoveInput.Value = horizontalInput;

            if (Input.GetKeyUp(KeyCode.Q)) 
                _vanish.OnNext(Unit.Default);
        }
    }
}