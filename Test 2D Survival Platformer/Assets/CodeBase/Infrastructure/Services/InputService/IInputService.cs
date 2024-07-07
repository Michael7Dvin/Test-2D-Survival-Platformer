using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        event Action<float> HorizontalMoveInput;
    }
}