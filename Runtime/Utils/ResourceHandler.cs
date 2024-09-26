using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Yogi.RaidSurvival.Runtime.Utils {
    public static class ResourceHandler {
        public static T InstantiateObject<T>(string addressablePath, Transform parent = null, bool worldPositionStays = false) where T : Component {
            var op = Addressables.InstantiateAsync(addressablePath, parent, worldPositionStays);
            var result = op.WaitForCompletion().GetComponent<T>();
            return result;
        }

        public static GameObject InstantiateObject(string addressablePath, Transform parent = null, bool worldPositionStays = false) {
            var op = Addressables.InstantiateAsync(addressablePath + ".prefab", parent, worldPositionStays);
            var result = op.WaitForCompletion();

            return result;
        }

        public static async UniTask<T> InstantiateObjectAsync<T>(string addressablePath, Transform parent = null, bool worldPositionStays = false) where T : Component {
            var op = Addressables.InstantiateAsync(addressablePath, parent, worldPositionStays);
            var inProgress = true;
            T result = null;
            op.Completed += handle => {
                inProgress = false;
                if (handle.Result != null) {
                    result = handle.Result.GetComponent<T>();
                }
            };
            await UniTask.WaitUntil(() => !inProgress);
            return result;
        }

        public static void InstantiateObjectAsync(string addressablePath, Transform parent = null, Action<GameObject> onCreated = null, bool worldPositionStays = false) {
            Addressables.InstantiateAsync(addressablePath, parent, worldPositionStays).Completed += handle => {
                onCreated?.Invoke(handle.Result);
            };
        }

        public static void InstantiateObjectAsync<T>(string addressablePath, Transform parent, Action<T> onCreated, bool worldPositionStays = false) {
            Addressables.InstantiateAsync(addressablePath, parent, worldPositionStays).Completed += handle => {
                var go = handle.Result;
                onCreated?.Invoke(go.GetComponent<T>());
            };
        }
        
        public static T LoadAsset<T>(string path) {
            var op = Addressables.LoadAssetAsync<T>(path);
            var result = op.WaitForCompletion();

            return result;
        }

        public static void LoadAssetAsync<T>(string path, Action<T> onLoaded) {
            Addressables.LoadAssetAsync<T>(path).Completed += handle => {
                onLoaded.Invoke(handle.Result);
            };
        }

        public static void LoadSpriteAsync(string path, Action<Sprite> onLoaded) {
            Addressables.LoadAssetAsync<Sprite>(path).Completed += handle => {
                onLoaded.Invoke(handle.Result);
            };
        }

        public static void LoadSceneAsync(string path, LoadSceneMode mode) {
            Addressables.LoadSceneAsync(path, mode);
        }
    }
}
