using System;
using GameCore.Events;
using GameCore.ScriptableObjects;
using GameLoop;
using UnityEngine;
using VContainer.Unity;

namespace GameCore
{
    public class PlayerInput : ITickable, IDisposable, IPlayerInput
    {
        public Vector3 MousePosition {private set; get; }
        
        private readonly EventBus _eventBus;
        private readonly GameSettings _settings;
        private bool _gameRunning;
        private readonly Camera _camera;
        private Action<KeyCode> _relevantInputCb;

        private void GameStart(BaseEventParams eventParams)
        {
            _gameRunning = true;
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe(GameplayEvent.GameStart, GameStart);
        }

        public void Tick()
        {
            if (_gameRunning)
                MousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            
            if(Input.GetKeyDown(_settings.PauseKey))
                _relevantInputCb(_settings.PauseKey);
            
            if(Input.GetKeyDown(_settings.ResetPositionKey))
                _relevantInputCb(_settings.ResetPositionKey);
        }
        
        private PlayerInput(EventBus eventBus, GameSettings settings, IGameDirector director)
        {
            _camera = Camera.main;
            _eventBus = eventBus;
            _settings = settings;
            _relevantInputCb = director.PlayerInput;
            _eventBus.Subscribe(GameplayEvent.GameStart, GameStart);




            _gameRunning = true;
        }
    }
}