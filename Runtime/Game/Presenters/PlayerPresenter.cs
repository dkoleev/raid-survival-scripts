using UnityEngine;

namespace Yogi.RaidSurvival.Runtime.Game.Presenters {
    public class PlayerPresenter : MonoBehaviour {
        private Transform _root;

        private void Awake() {
            _root = transform;
        }

        private void Start() {
            //MoveToDefaultPosition();
        }

        private void MoveToDefaultPosition() {
            var defaultPosition = GameObject.FindGameObjectWithTag("PlayerDefaultPosition");
            if (defaultPosition == null) {
               // _log.Message($"Not found object with tag PlayerDefaultPosition");
                return;
            }
            
            _root.position = defaultPosition.transform.position;
            _root.rotation = defaultPosition.transform.rotation;
        }
    }
}
