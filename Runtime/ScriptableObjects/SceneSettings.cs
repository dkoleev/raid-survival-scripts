using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Yogi.RaidSurvival.Runtime.ScriptableObjects {
    [Serializable]
    public class SceneSettings {
        public enum SceneType {
            Core = 1,
            EnvBase = 2,
            LevelBase = 3
        }
        
        [SerializedDictionary("Type", "Addressable path")]
        [field:SerializeField] public SerializedDictionary<SceneType, string> Scenes { get; private set; }
    }
}
