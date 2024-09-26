using MessagePipe;
using VContainer;
using VContainer.Unity;
using Yogi.RaidSurvival.Runtime.Data;

namespace Yogi.RaidSurvival.Runtime.DiScopes {
    public class GameLifetimeScope : LifetimeScope {
        protected override void Configure(IContainerBuilder builder) {
            // RegisterMessagePipe returns options.
            var options = builder.RegisterMessagePipe(/* configure option */);
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
            
            builder.RegisterEntryPoint<Boot>();
            builder.Register<GameData>(Lifetime.Singleton);
        }
    }
}
