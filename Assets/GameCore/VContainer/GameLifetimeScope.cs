using Arena;
using GameCore;
using GameCore.Events;
using GameCore.ScriptableObjects;
using GameCore.UI;
using GameLoop;
using Puck;
using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private ArenaScript _arena;
        [SerializeField] private PuckScript _puck;
        [SerializeField] private ScoreView _scoreView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameDirector>();
            builder.Register<EventBus>(Lifetime.Singleton);
            builder.RegisterComponent(_arena).AsImplementedInterfaces();
            builder.RegisterComponent(_puck).AsImplementedInterfaces();
            builder.RegisterComponent(_scoreView).AsImplementedInterfaces();
            builder.Register<PlayerInput>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterInstance(_gameSettings);
        }
    }
}


