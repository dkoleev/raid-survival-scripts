using JetBrains.Annotations;
using VContainer;
using VContainer.Unity;
using Yogi.RaidSurvival.Runtime.Data;

namespace Yogi.RaidSurvival.Runtime {
    [UsedImplicitly]
    public class Boot : IStartable {
        private readonly GameData _gameData;
        private readonly SceneLoader _sceneLoader;

        [Inject]
        private Boot(GameData gameData, SceneLoader sceneLoader) {
            _gameData = gameData;
            _sceneLoader = sceneLoader;
        }

        public void Start() {
            StartGame();
        }

        private void StartGame() {
            LoadData();
            LoadScenes();
        }

        private void LoadData() {
            _gameData.Load();
        }

        private void LoadScenes() {
            _sceneLoader.LoadCommonScenes();
        }
    }
}
