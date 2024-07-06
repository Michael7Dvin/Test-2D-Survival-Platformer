﻿using UnityEngine;

namespace CodeBase.Gameplay.Character
{
    public class Mover
    {
        private readonly float _moveSpeed;
        private readonly Rigidbody2D _rigidbody;
        
        public Mover(float moveSpeed, Rigidbody2D rigidbody)
        {
            _moveSpeed = moveSpeed;
            _rigidbody = rigidbody;
        }

        public void Move(Vector2 direction) => 
            _rigidbody.velocity = direction * _moveSpeed;
    }
}