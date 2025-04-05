using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace RaidSurvival.Runtime.Game {
    [UsedImplicitly]
    public class AppConfig : IStartable {
        public void Start() {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
    }
}
