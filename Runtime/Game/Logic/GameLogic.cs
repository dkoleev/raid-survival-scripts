using System;
using Cysharp.Threading.Tasks;
using VContainer;
using Yogi.RaidSurvival.Runtime.Systems;

namespace Yogi.RaidSurvival.Runtime.Game.Logic {
    public class GameLogic {
        private readonly SaveSystem _saveSystem;

        [Inject]
        private GameLogic(SaveSystem saveSystem) {
            _saveSystem = saveSystem;
        }

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
