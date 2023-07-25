using System;
using GameCore.Events;
using UnityEngine;
using VContainer;

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
        _eventCb.Invoke(GameplayEvent.Score, new ScoreParams(!_playerGoal));
    }
}
