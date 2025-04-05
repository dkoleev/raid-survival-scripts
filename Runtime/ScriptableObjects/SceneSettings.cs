using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace RaidSurvival.Runtime.ScriptableObjects {
    [Serializable]
    public class SceneSettings {
        public enum SceneType {
            Core = 1,
            EnvBase = 2,
            LevelBase = 3,
            Debug = 4,
            Player = 5,
            UI = 6
        }
        
        [SerializedDictionary("Type", "Addressable path")]
        [field:SerializeField] public SerializedDictionary<SceneType, string> Scenes { get; private set; }
    }
}
