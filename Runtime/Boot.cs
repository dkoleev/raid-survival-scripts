using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using RaidSurvival.Runtime.Data;
using RaidSurvival.Runtime.Systems;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RaidSurvival.Runtime {
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
            var player = GameObject.FindWithTag("Player");
            var spawnPoint = GameObject.FindWithTag("PlayerSpawnPoint");
            player.gameObject.SetActive(false);
            player.transform.position = spawnPoint.transform.position;
            player.gameObject.SetActive(true);
        }

        private async UniTask LoadProgress() {
            await _saveSystem.LoadAsync();
        }

        private void LoadData() {
            _gameData.Load();
        }

        private async UniTask LoadScenes() {
            await _sceneLoader.LoadCommonScenes();
            await _sceneLoader.LoadPlayerScene();
            await _sceneLoader.LoadHomeLocationScene();
            await _sceneLoader.LoadUiScene();
            
#if DEBUG
            await _sceneLoader.LoadDebugScene();
#endif
        }
    }
}
