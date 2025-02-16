using UnityEngine;
using VContainer;
using Yogi.RaidSurvival.Runtime.Utils;

namespace Yogi.RaidSurvival.Runtime.Game.Logic {
    public class PlayerLogic {
        private readonly Transform _rootTransform;
        private readonly GameLogger _gameLogger;

        [Inject]
        public PlayerLogic(Transform rootTransform, GameLogger gameLogger) {
            _rootTransform = rootTransform;
            _gameLogger = gameLogger;
        }

        private void TestLogic() {
            
        }
        
        /*private void MoveToDefaultPosition() {
            var defaultPosition = GameObject.FindGameObjectWithTag("PlayerDefaultPosition");
            if (defaultPosition == null) {
                _log.Message($"Not found object with tag PlayerDefaultPosition");
                return;
            }
            
            _root.position = defaultPosition.transform.position;
            _root.rotation = defaultPosition.transform.rotation;
        }*/
    }
}
