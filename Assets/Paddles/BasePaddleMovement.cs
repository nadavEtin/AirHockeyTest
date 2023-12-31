﻿using GameCore.Events;
using UnityEngine;

namespace Paddles
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BasePaddleMovement : MonoBehaviour
    {
        protected Boundaries _movementBoundaries;
        protected float _speed, _maximumSpeed;
        protected Vector3 _startingPos;
        protected Vector3 _movementDestination;
        protected bool _gameRunning;
        
        private EventBus _eventBus;
        private Rigidbody _rb;

        protected void BaseSetup(EventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe(GameplayEvent.Reset, Reset);
            _eventBus.Subscribe(GameplayEvent.GamePause, GamePause);
            _eventBus.Subscribe(GameplayEvent.GameStart, GameStart);
        }

        protected virtual void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _startingPos = transform.position;
        }

        protected virtual void FixedUpdate()
        {
            var dir = _movementDestination - transform.position;
            _rb.velocity = dir * (_speed * Time.fixedDeltaTime);
        }

        protected bool OutOfBounds()
        {
            var curPos = transform.position;
            return curPos.x <= _movementBoundaries.Up || curPos.x >= _movementBoundaries.Down ||
                   curPos.z <= _movementBoundaries.Left || curPos.z >= _movementBoundaries.Right;
        }

        //Keep the paddles inside the play area
        protected void LimitMovement()
        {
            var position = transform.position;
            position = new Vector3(Mathf.Clamp(position.x, _movementBoundaries.Up, _movementBoundaries.Down),
                position.y, Mathf.Clamp(position.z, _movementBoundaries.Left, _movementBoundaries.Right));
            transform.position = position;
            _rb.velocity *= 0.4f;
        }
        
        private void GamePause(BaseEventParams eventParams)
        {
            _rb.velocity = Vector3.zero;
            _gameRunning = false;
        }
        
        //Also used to resume the game after pausing
        private void GameStart(BaseEventParams eventParams)
        {
            _gameRunning = true;
        }
        
        private void Reset(BaseEventParams eventParams)
        {
            transform.position = _startingPos;
            _rb.velocity = Vector3.zero;
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe(GameplayEvent.Reset, Reset);
            _eventBus.Unsubscribe(GameplayEvent.GamePause, GamePause);
            _eventBus.Unsubscribe(GameplayEvent.GameStart, GameStart);
        }
    }
    
    public struct Boundaries
    {
        public float Up { get; }
        public float Down { get; }
        public float Left { get; }
        public float Right { get; }

        public Boundaries(float up, float down, float left, float right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }
    }
}