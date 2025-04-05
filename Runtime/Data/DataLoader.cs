using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using RaidSurvival.Runtime.Utils;
using UnityEngine;

namespace RaidSurvival.Runtime.Data {
    internal class DataLoader {
        private static readonly string ConfigsDirectory = "Data";
        
        private string GetStringJson<T>() {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<DataPathAttribute>();
            var path = $"{ConfigsDirectory}/{attribute.DataPath}";
            var asset = ResourceHandler.LoadAsset<TextAsset>(path + ".json");

            return asset.text;
        }
        
        public T Deserialize<T>(JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<T>(GetStringJson<T>(), settings);
        }

        public T1 Deserialize<T1, T2>(JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<T1>(GetStringJson<T2>(), settings);
        }

        public Dictionary<T1, T2> DeserializeDictionary<T1, T2>(JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<Dictionary<T1, T2>>(GetStringJson<T2>(), settings);
        }

        public Dictionary<string, T> DeserializeStringKeyDictionary<T>(params JsonConverter[] converters) {
            return JsonConvert.DeserializeObject<Dictionary<string, T>>(GetStringJson<T>(), converters);
        }

        public Dictionary<string, T> DeserializeStringKeyDictionary<T>(JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<Dictionary<string, T>>(GetStringJson<T>(), settings);
        }

        public List<T> DeserializeList<T>(JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<List<T>>(GetStringJson<T>(), settings);
        }
    }
}
