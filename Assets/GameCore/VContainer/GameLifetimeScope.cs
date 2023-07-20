using Assets.Scripts.Utility;
using GameCore;
using GameCore.Json;
using GameCore.ScriptableObjects;
using GameCore.ServerComs;
using GameCore.UI;
using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private AssetRefs _assetRefs;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameDirector>();
            builder.Register<EventBus>(Lifetime.Singleton);
            builder.Register<UIManager>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.RegisterInstance(_assetRefs);
        }
    }
}


