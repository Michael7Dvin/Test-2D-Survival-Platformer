using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.InputService
{
    public class InputService : IInputService, ITickable
    {
        public event Action<float> HorizontalMoveInput;
        
        
        public void Tick()
        {
            float horizontal = Input.GetAxis("Horizontal");
            
            if (horizontal != 0) 
                HorizontalMoveInput?.Invoke(horizontal);
        }
    }
}