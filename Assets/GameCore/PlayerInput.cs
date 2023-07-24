using System;
using GameCore.Events;
using UnityEngine;
using VContainer.Unity;

namespace GameCore
{
    public class PlayerInput : IFixedTickable, IDisposable, IPlayerInput
    {
        private readonly EventBus _eventBus;
        private bool _gameRunning;
        private readonly Camera _camera;
        public Vector3 MousePosition {private set; get; }

        private void GameStart(BaseEventParams eventParams)
        {
            _gameRunning = true;
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe(GameplayEvent.GameStart, GameStart);
        }

        public void FixedTick()
        {
            /*if (_gameRunning)
            {*/
            MousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            //}
        }
        
        private PlayerInput(EventBus eventBus)
        {
            _camera = Camera.main;
            _eventBus = eventBus;
            _eventBus.Subscribe(GameplayEvent.GameStart, GameStart);
        }
    }
}