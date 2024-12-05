using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Yogi.RaidSurvival.Runtime.ScriptableObjects;

namespace Yogi.RaidSurvival.Runtime {
    [UsedImplicitly]
    public class SceneLoader {
        private readonly SceneSettings _sceneSettings;

        private SceneLoader(SceneSettings sceneSettings) {
            _sceneSettings = sceneSettings;
        }
        
        public async UniTask LoadCommonScenes() {
            await Addressables.LoadSceneAsync(_sceneSettings.Scenes[SceneSettings.SceneType.Core], LoadSceneMode.Additive);
            await Addressables.LoadSceneAsync(_sceneSettings.Scenes[SceneSettings.SceneType.EnvBase], LoadSceneMode.Additive);
        }

        public async UniTask LoadHomeLocationScene() {
            await Addressables.LoadSceneAsync(_sceneSettings.Scenes[SceneSettings.SceneType.LevelBase], LoadSceneMode.Additive);
        }
        
        public async UniTask LoadDebugScene() {
            await Addressables.LoadSceneAsync(_sceneSettings.Scenes[SceneSettings.SceneType.Debug], LoadSceneMode.Additive);
        }
        
        public async UniTask LoadPlayerScene() {
            await Addressables.LoadSceneAsync(_sceneSettings.Scenes[SceneSettings.SceneType.Player], LoadSceneMode.Additive);
        }
        
        public async UniTask LoadUiScene() {
            await Addressables.LoadSceneAsync(_sceneSettings.Scenes[SceneSettings.SceneType.UI], LoadSceneMode.Additive);
        }
    }
}
