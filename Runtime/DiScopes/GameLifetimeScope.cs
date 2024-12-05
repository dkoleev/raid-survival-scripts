using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yogi.RaidSurvival.Runtime.Data;
using Yogi.RaidSurvival.Runtime.Game.Factories;
using Yogi.RaidSurvival.Runtime.Game.Logic;
using Yogi.RaidSurvival.Runtime.ScriptableObjects;
using Yogi.RaidSurvival.Runtime.Utils;

namespace Yogi.RaidSurvival.Runtime.DiScopes {
    public class GameLifetimeScope : LifetimeScope {
        [SerializeField] private GameSettings gameSettings;
        
        protected override void Configure(IContainerBuilder builder) {
            RegisterMessagePipe(builder);
            RegisterGameSettings(builder);
            builder.RegisterEntryPoint<Boot>();
            builder.Register<Logger>(Lifetime.Singleton);
            builder.Register<GameData>(Lifetime.Singleton);
            builder.Register<SceneLoader>(Lifetime.Singleton);

            builder.RegisterFactory<Transform, PlayerLogic>(container => // container is an IObjectResolver
            {
                var log = container.Resolve<Log>(); // Resolve per scope
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
