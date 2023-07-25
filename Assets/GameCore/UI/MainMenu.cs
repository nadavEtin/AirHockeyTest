using GameCore.Events;
using GameCore.ScriptableObjects;
using TMPro;
using UnityEngine;
using VContainer;

namespace GameCore.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _howToPlayInstructions;
        [SerializeField] private TextMeshProUGUI _howToPlayText;
        
        private EventBus _eventBus;

        public void PlayBtnClick()
        {
            _eventBus.Publish(GameplayEvent.GameStart, new EmptyParams());
            gameObject.SetActive(false);
        }
        
        public void HowToPlayBtnClick()
        {
            _howToPlayInstructions.gameObject.SetActive(true);
        }

        public void HowToPlayCloseBtnClick()
        {
            _howToPlayInstructions.gameObject.SetActive(false);
        }
        
        public void ExitBtnClick()
        {
            _eventBus.Publish(GameplayEvent.ExitGame, new EmptyParams());
        }
        
        [Inject]
        private void Construct(EventBus eventBus, GameSettings settings)
        {
            _eventBus = eventBus;
            _howToPlayText.text = settings.HowToPlayText;
            _eventBus.Subscribe(GameplayEvent.GamePause, ShowMenu);
        }

        //Show the menu when pausing the game
        private void ShowMenu(BaseEventParams eventParams)
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe(GameplayEvent.GamePause, ShowMenu);
        }
    }
}
