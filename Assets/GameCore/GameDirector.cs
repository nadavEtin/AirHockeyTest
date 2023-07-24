using GameCore.Events;
using UnityEngine;
using VContainer.Unity;

namespace GameCore
{
    public class GameDirector : IStartable, ITickable
    {
        private readonly EventBus _eventBus;
        
        public GameDirector(EventBus bus)
        {
            _eventBus = bus;
            _eventBus.Subscribe(GameplayEvent.ExitGame, Exit);
        }
        
        public void Start()
        {
            
        
        }

        public void Tick()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                _eventBus.Publish(GameplayEvent.GamePause, new EmptyParams());
        }

        private void Exit(BaseEventParams eventParams)
        {
            Application.Quit();
        }
    }
}