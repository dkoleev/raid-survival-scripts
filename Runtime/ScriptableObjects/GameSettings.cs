using UnityEngine;

namespace Yogi.RaidSurvival.Runtime.ScriptableObjects {
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "Game/Configuration", order = 0)]
    public class GameSettings : ScriptableObject {
        [field: SerializeField] public SceneSettings SceneSettings { get; private set; }
    }
}
