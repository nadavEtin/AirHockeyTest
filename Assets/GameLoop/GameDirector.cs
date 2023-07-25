using GameCore.Events;
using GameCore.ScriptableObjects;
using GameCore.UI;
using UnityEditor;
using UnityEngine;

namespace GameLoop
{
    public class GameDirector : IGameDirector
    {
        private readonly EventBus _eventBus;
        private readonly IScoreKeeper _scoreKeeper;
        private readonly IScoreView _scoreView;
        private readonly GameSettings _settings;
        
        private GameDirector(EventBus bus, IScoreView scoreView, GameSettings settings)
        {
            _eventBus = bus;
            _settings = settings;
            _scoreKeeper = new ScoreKeeper(_settings.ScoreRequiredToWin);
            _scoreView = scoreView;
            _eventBus.Subscribe(GameplayEvent.ExitGame, Exit);
            _eventBus.Subscribe(GameplayEvent.Score, OnScore);
        }

        public void PlayerInput(KeyCode keyCode)
        {
            if(keyCode == _settings.ResetPositionKey)
                _eventBus.Publish(GameplayEvent.Reset, new EmptyParams());
            
            if(keyCode == _settings.PauseKey)
                _eventBus.Publish(GameplayEvent.GamePause, new EmptyParams());
        }

        private void OnScore(BaseEventParams eventParams)
        {
            var parameters = (ScoreParams)eventParams;
            _scoreKeeper.UpdateScore(parameters.PlayerScored);
            _scoreView.ScoreText.text = _scoreKeeper.CurrentScoreString;
            
            //If either player scored enough to win end the game, otherwise reset positions
            _eventBus.Publish(_scoreKeeper.CheckGameOver() ? GameplayEvent.GameOver : GameplayEvent.Reset,
                new EmptyParams());
        }

        private void Exit(BaseEventParams eventParams)
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}