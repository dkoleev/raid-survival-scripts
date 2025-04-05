using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using RaidSurvival.Runtime.Systems;
using VContainer;

namespace RaidSurvival.Runtime.Game.Logic {
    public class GameLogic {
        private readonly SaveSystem _saveSystem;

        [Inject]
        private GameLogic(SaveSystem saveSystem) {
            _saveSystem = saveSystem;
        }

        [UsedImplicitly]
        void OnApplicationQuit() {
            _saveSystem.Save();
        }

        private async UniTaskVoid AutoSaveLoop() {
            while (true) {
                await UniTask.Delay(TimeSpan.FromMinutes(2));
                await _saveSystem.SaveAsync();
            }
        }
    }
}
