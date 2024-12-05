using VContainer;
using Yogi.RaidSurvival.Runtime.Utils;

namespace Yogi.RaidSurvival.Runtime.Game.Logic {
    public class BuildingLogic {
        private readonly Log _log;

        [Inject]
        private BuildingLogic(Log log) {
            _log = log;
        }
    }
}
