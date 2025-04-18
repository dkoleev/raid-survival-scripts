﻿using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using RaidSurvival.Runtime.ScriptableObjects;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace RaidSurvival.Runtime {
    [UsedImplicitly]
    public class SceneLoader {
        private readonly SceneSettings _sceneSettings;

        private SceneLoader(SceneSettings sceneSettings) {
            _sceneSettings = sceneSettings;
        }

        public async UniTask LoadCommonScenes() {
            await LoadScene(_sceneSettings.Scenes[SceneSettings.SceneType.Core], LoadSceneMode.Additive);
            //await LoadScene(_sceneSettings.Scenes[SceneSettings.SceneType.EnvBase], LoadSceneMode.Additive);
        }

        public async UniTask LoadHomeLocationScene() {
            await LoadScene(_sceneSettings.Scenes[SceneSettings.SceneType.LevelBase], LoadSceneMode.Additive);
        }
        
        public async UniTask LoadDebugScene() {
            await LoadScene(_sceneSettings.Scenes[SceneSettings.SceneType.Debug], LoadSceneMode.Additive);
        }
        
        public async UniTask LoadPlayerScene() {
            await LoadScene(_sceneSettings.Scenes[SceneSettings.SceneType.Player], LoadSceneMode.Additive);
        }
        
        public async UniTask LoadUiScene() {
            await LoadScene(_sceneSettings.Scenes[SceneSettings.SceneType.UI], LoadSceneMode.Additive);
        }

        private async UniTask LoadScene(string path, LoadSceneMode mode) {
            await Addressables.LoadSceneAsync($"{path}.unity", mode);
            
        }
    }
}
