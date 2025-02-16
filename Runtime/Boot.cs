using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using VContainer;
using VContainer.Unity;
using Yogi.RaidSurvival.Runtime.Data;
using Yogi.RaidSurvival.Runtime.Systems;

namespace Yogi.RaidSurvival.Runtime {
    [UsedImplicitly]
    public class Boot : IStartable {
        private readonly GameData _gameData;
        private readonly SceneLoader _sceneLoader;
        private readonly SaveSystem _saveSystem;

        [Inject]
        private Boot(GameData gameData, SceneLoader sceneLoader, SaveSystem saveSystem) {
            _gameData = gameData;
            _sceneLoader = sceneLoader;
            _saveSystem = saveSystem;
        }

        public void Start() {
            StartGame().Forget();
        }

        private async UniTaskVoid StartGame() {
            await LoadProgress();
            LoadData();
            await LoadScenes();
        }

        private async UniTask LoadProgress() {
            await _saveSystem.LoadAsync();
        }

        private void LoadData() {
            _gameData.Load();
        }

        private async UniTask LoadScenes() {
            await _sceneLoader.LoadCommonScenes();
            await _sceneLoader.LoadHomeLocationScene();
            await _sceneLoader.LoadPlayerScene();
            await _sceneLoader.LoadUiScene();
            
#if DEBUG
            await _sceneLoader.LoadDebugScene();
#endif
        }
    }
}
