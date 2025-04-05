using MessagePipe;
using RaidSurvival.Runtime.Data;
using RaidSurvival.Runtime.Game;
using RaidSurvival.Runtime.Game.Logic;
using RaidSurvival.Runtime.ScriptableObjects;
using RaidSurvival.Runtime.State;
using RaidSurvival.Runtime.Systems;
using RaidSurvival.Runtime.Utils;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RaidSurvival.Runtime.DiScopes {
    public class GameLifetimeScope : LifetimeScope {
        [SerializeField] private GameSettings gameSettings;
        
        protected override void Configure(IContainerBuilder builder) {
            RegisterMessagePipe(builder);
            RegisterGameSettings(builder);

            builder.Register<AppConfig>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.RegisterEntryPoint<Boot>();
            builder.Register<GameLogger>(Lifetime.Singleton);
            builder.Register<GameData>(Lifetime.Singleton);
            builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.Register<SaveSystem>(Lifetime.Singleton);
            builder.Register<GameState>(Lifetime.Singleton);

            builder.RegisterFactory<Transform, PlayerLogic>(container => // container is an IObjectResolver
            {
                var log = container.Resolve<GameLogger>(); // Resolve per scope
                return rootTransform => new PlayerLogic(rootTransform, log); // Execute per factory invocation
            }, Lifetime.Scoped);
        }

        private void RegisterMessagePipe(IContainerBuilder builder) {
            // RegisterMessagePipe returns options.
            var options = builder.RegisterMessagePipe(/* configure option */);
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
        }

        private void RegisterGameSettings(IContainerBuilder builder) {
            builder.RegisterInstance(gameSettings.SceneSettings);
        }
    }
}
