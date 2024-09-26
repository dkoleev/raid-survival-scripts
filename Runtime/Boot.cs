using JetBrains.Annotations;
using VContainer;
using VContainer.Unity;
using Yogi.RaidSurvival.Runtime.Data;

namespace Yogi.RaidSurvival.Runtime {
    [UsedImplicitly]
    public class Boot : IStartable {
        private readonly GameData _gameData;

        [Inject]
        private Boot(GameData gameData) {
            _gameData = gameData;
        }
        
        public void Start() {
            StartGame();
        }

        private void StartGame() {
            LoadData();
        }

        private void LoadData() {
            _gameData.Load();
        }

        private void Test() {
            
        }
    }
}
