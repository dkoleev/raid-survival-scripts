using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yogi.RaidSurvival.Runtime.Data;
using Yogi.RaidSurvival.Runtime.ScriptableObjects;

namespace Yogi.RaidSurvival.Runtime.DiScopes {
    public class GameLifetimeScope : LifetimeScope {
        [SerializeField] private GameSettings gameSettings;
        
        protected override void Configure(IContainerBuilder builder) {
            RegisterMessagePipe(builder);
            RegisterGameSettings(builder);
            builder.RegisterEntryPoint<Boot>();
            builder.Register<GameData>(Lifetime.Singleton);
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
