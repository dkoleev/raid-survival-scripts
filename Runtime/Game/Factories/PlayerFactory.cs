using UnityEngine;
using Yogi.RaidSurvival.Runtime.Game.Logic;
using Yogi.RaidSurvival.Runtime.Utils;

namespace Yogi.RaidSurvival.Runtime.Game.Factories {
    public class PlayerFactory {
        private readonly GameLogger _gameLogger;

        public PlayerFactory(GameLogger gameLogger) {
            _gameLogger = gameLogger;
        }

        public PlayerLogic Create(Transform playerTransform) => new PlayerLogic(playerTransform, _gameLogger);
    }
}
