using GameCore.Events;
using GameCore.ScriptableObjects;
using UnityEngine;
using VContainer;

namespace Puck
{
    [RequireComponent(typeof(Rigidbody))]
    public class PuckScript : MonoBehaviour, IPuckScript
    {
        public Transform PuckTransform => transform;

        private EventBus _eventBus;
        private Vector3 _startingPos;
        private Rigidbody _rb;
        private float _maxSpeed;

        [Inject]
        private void Construct(EventBus eventBus, GameSettings settings)
        {
            _eventBus = eventBus;
            _maxSpeed = settings.PuckMaxSpeed;
            _startingPos = transform.position;
            _rb = GetComponent<Rigidbody>();
            _eventBus.Subscribe(GameplayEvent.Reset, ResetPos);
            _eventBus.Subscribe(GameplayEvent.GamePause, GamePause);
        }

        private void FixedUpdate()
        {
            //Limit the puck to a reasonable movement speed
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxSpeed);
        }

        private void ResetPos(BaseEventParams eventParams)
        {
            transform.position = _startingPos;
            _rb.velocity = Vector3.zero;
        }

        private void GamePause(BaseEventParams eventParams)
        {
            _rb.velocity = Vector3.zero;
        }
    }
}