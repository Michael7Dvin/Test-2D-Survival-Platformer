using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Components.Movement
{
    public class ProjectileMover : IMover
    {
        private readonly float _moveSpeed;
        private readonly Rigidbody2D _rigidbody;
        
        private readonly ReactiveProperty<bool> _isMoving = new();

        public ProjectileMover(float moveSpeed, Rigidbody2D rigidbody)
        {
            _moveSpeed = moveSpeed;
            _rigidbody = rigidbody;
        }

        public bool Enabled { get; set; }
        public IReadOnlyReactiveProperty<bool> IsMoving => _isMoving;

        public void Move(Vector2 direction, float deltaTime)
        {
            if (Enabled == false || direction == Vector2.zero)
            {
                _isMoving.Value = false;
                return;
            }
            
            _isMoving.Value = true;
            
            Vector2 characterPosition = _rigidbody.position;
            Vector2 newPosition = characterPosition + direction * (_moveSpeed * deltaTime);
            
            _rigidbody.MovePosition(newPosition);
        }
    }
}