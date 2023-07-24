using System;
using GameCore;
using GameCore.Events;
using GameCore.ScriptableObjects;
using UnityEngine;
using VContainer;

namespace Paddles
{
    public class PlayerMovementController : BasePaddleMovement
    {
        private IPlayerInput _playerInput;
        

        protected override void FixedUpdate()
        {
            /*if (_gameRunning == false)
            return;*/

            if (Input.GetMouseButton(0))
            {
                _movementDestination = _playerInput.MousePosition;
                base.FixedUpdate();
            }

            if(OutOfBounds())
                LimitMovement();
        }
        
        [Inject]
        private void Construct(IPlayerInput playerInput, GameSettings settings, EventBus eventBus)
        {
            _playerInput = playerInput;
            _movementBoundaries =  settings.PlayerBoundaries;
            _speed = settings.PlayerMovementSpeed;
            BaseSetup(eventBus);
        }
    }
}