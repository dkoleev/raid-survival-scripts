using System;
using Newtonsoft.Json;

namespace RaidSurvival.Runtime.Data.Core {
    [Serializable]
    [DataPath("core/resources")]
    public class ResourceData {
        [JsonProperty("id")] public readonly string Id;
    }
}
