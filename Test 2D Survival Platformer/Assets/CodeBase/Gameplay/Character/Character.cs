using CodeBase.Gameplay.Character.Movement;
using CodeBase.Infrastructure.Services.InputService;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Character
{
    public class Character : MonoBehaviour
    {
        [Inject] private readonly IInputService _inputService;
        
        private Mover _mover;

        public void Construct(Mover mover)
        {
            _mover = mover;
        }

        private void Start()
        {
            _inputService.HorizontalMoveInput
                .Subscribe(xAxis => _mover.Move(new Vector2(xAxis, 0), Time.deltaTime))
                .AddTo(this);
        }
    }
}