using UnityEngine;
using Yogi.RaidSurvival.Runtime.Game.Logic;
using Yogi.RaidSurvival.Runtime.Utils;

namespace Yogi.RaidSurvival.Runtime.Game.Factories {
    public class PlayerFactory {
        private readonly Log _log;

        public PlayerFactory(Log log) {
            _log = log;
        }

        public PlayerLogic Create(Transform playerTransform) => new PlayerLogic(playerTransform, _log);
    }
}
