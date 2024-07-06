using UnityEngine;

namespace CodeBase.Gameplay.Character
{
    public class Character : MonoBehaviour
    {
        private Mover _mover;

        private void Update()
        {
            float moveInput = Input.GetAxis("Horizontal");
            Vector2 moveDirection = new Vector2(moveInput, 0);
            
            _mover.Move(moveDirection);
        }
        
        public void Construct(Mover mover)
        {
            _mover = mover;
        }
    }
}