using System;
using GameCore.Events;
using UnityEngine;
using VContainer;

namespace Arena
{
    public class ScoreTrigger : MonoBehaviour
    {
        [SerializeField] private bool _playerGoal;

        private Action<GameplayEvent, BaseEventParams> _eventCb;

        [Inject]
        private void Construct(EventBus eventBus)
        {
            _eventCb = eventBus.Publish;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            //Send the opposite of the goal's owner as the scorer
            //example- if a goal was scored to the ai's goal, its a point for the player
            _eventCb.Invoke(GameplayEvent.Score, new ScoreParams(!_playerGoal));
        }
    }
}
