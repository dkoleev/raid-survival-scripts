using JetBrains.Annotations;
using UnityEngine;

namespace Yogi.RaidSurvival.Runtime.Utils {
    [UsedImplicitly]
    public class GameLogger {
        public void Message(string message) {
            Debug.Log(message);
        }

        public void LogWarning(string message) {
            Debug.LogWarning(message);
        }

        public void LogError(string message) {
            Debug.LogError(message);
        }
    }
}
