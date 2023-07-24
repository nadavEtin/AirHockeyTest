using GameCore.Events;
using GameCore.ScriptableObjects;
using Puck;
using UnityEngine;
using VContainer;

namespace Paddles
{
    public class AiMovementController : BasePaddleMovement
    {
        private Transform _puckTransform;

        protected override void FixedUpdate()
        {
            if (_gameRunning == false) return;

            _speed = _maximumSpeed;
            var curPuckPos = _puckTransform.position;
            
            //The puck is the in player's half
            if (curPuckPos.z >= _movementBoundaries.Right)
            {
                _movementDestination = _startingPos;
                _speed = Random.Range(_maximumSpeed * 0.4f, _maximumSpeed * 0.8f);
            }
                
                /*_movementDestination = new Vector3(Mathf.Clamp(curPuckPos.x, _movementBoundaries.Up,
                    _movementBoundaries.Down), transform.position.y, _startingPos.z);*/
            //The puck is in the ai's half
            else if (curPuckPos.z <= _movementBoundaries.Right)
                _movementDestination = new Vector3(Mathf.Clamp(curPuckPos.x, _movementBoundaries.Up,
                    _movementBoundaries.Down), transform.position.y, Mathf.Clamp(curPuckPos.z, _movementBoundaries.Left,
                    _movementBoundaries.Right));
            
            base.FixedUpdate();
        }

        [Inject]
        private void Construct(EventBus eventBus, IPuckScript puckScript, GameSettings settings)
        {
            _puckTransform = puckScript.PuckTransform;
            _movementBoundaries = settings.AiBoundaries;
            _maximumSpeed = settings.AiMovementSpeed;
            _speed = _maximumSpeed;
            BaseSetup(eventBus);
        }
    }
}