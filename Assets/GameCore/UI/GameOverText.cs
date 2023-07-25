using GameCore.Events;
using UnityEngine;
using VContainer;

namespace GameCore.UI
{
    public class GameOverText : MonoBehaviour
    {
        private EventBus _eventBus;
        
        [Inject]
        private void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe(GameplayEvent.GameOver, GameOver);
        }

        private void GameOver(BaseEventParams eventParams)
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe(GameplayEvent.GameOver, GameOver);
        }
    }
}
