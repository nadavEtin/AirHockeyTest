using System;
using GameCore.Events;
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

        [Inject]
        private void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
            _startingPos = transform.position;
            _rb = GetComponent<Rigidbody>();
            _eventBus.Subscribe(GameplayEvent.Reset, ResetPos);
            _eventBus.Subscribe(GameplayEvent.GamePause, GamePause);
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

        private void OnDestroy()
        {
            //_eventBus.Unsubscribe(GameplayEvent.Reset, ResetPos);
            //_eventBus.Unsubscribe(GameplayEvent.GamePause, GamePause);
        }
    }
}