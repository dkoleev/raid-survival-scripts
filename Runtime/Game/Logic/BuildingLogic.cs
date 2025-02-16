using VContainer;
using Yogi.RaidSurvival.Runtime.Utils;

namespace Yogi.RaidSurvival.Runtime.Game.Logic {
    public class BuildingLogic {
        private readonly GameLogger _gameLogger;

        [Inject]
        private BuildingLogic(GameLogger gameLogger) {
            _gameLogger = gameLogger;
        }
    }
}
