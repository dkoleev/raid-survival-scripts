using Cysharp.Threading.Tasks;
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
            StartGame().Forget();
        }

        private async UniTaskVoid StartGame() {
            LoadData();
            await LoadScenes();
        }

        private void LoadData() {
            _gameData.Load();
        }

        private async UniTask LoadScenes() {
#if DEBUG
            await _sceneLoader.LoadDebugScene();
#endif
            await _sceneLoader.LoadHomeLocationScene();
            await _sceneLoader.LoadCommonScenes();
            await _sceneLoader.LoadPlayerScene();
            await _sceneLoader.LoadUiScene();
        }
    }
}
