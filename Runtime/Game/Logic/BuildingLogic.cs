using RaidSurvival.Runtime.Utils;
using VContainer;

namespace RaidSurvival.Runtime.Game.Logic {
    public class BuildingLogic {
        private readonly GameLogger _gameLogger;

        [Inject]
        private BuildingLogic(GameLogger gameLogger) {
            _gameLogger = gameLogger;
        }
    }
}
