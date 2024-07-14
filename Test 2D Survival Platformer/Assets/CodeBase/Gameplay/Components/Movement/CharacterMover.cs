using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Components.Movement
{
    public class CharacterMover : IMover
    {
        private readonly float _moveSpeed;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        
        private readonly ReactiveProperty<bool> _isMoving = new();

        public CharacterMover(float moveSpeed, Rigidbody2D rigidbody)
        {
            _moveSpeed = moveSpeed;
            _rigidbody = rigidbody;
            _transform = rigidbody.transform;
        }

        public bool Enabled { get; set; } = true;
        public IReadOnlyReactiveProperty<bool> IsMoving => _isMoving;

        private bool IsFacingRight => 
            _transform.localScale.x > 0;

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
            
            FlipTowardMoveDirection(characterPosition, newPosition);
            
            _rigidbody.MovePosition(newPosition);
        }

        private void FlipTowardMoveDirection(Vector2 characterPosition, Vector2 newPosition)
        {
            if (characterPosition.x < newPosition.x && IsFacingRight == true)
                Flip();
            else if (characterPosition.x > newPosition.x && IsFacingRight == false)
                Flip();
            
            void Flip()
            {
                Vector3 scale = _transform.localScale;
                scale.x *= -1;  
                _transform.localScale = scale;
            }
        }
    }
}