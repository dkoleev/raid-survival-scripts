using System;
using Newtonsoft.Json;

namespace Yogi.RaidSurvival.Runtime.Data.Core {
    [Serializable]
    [DataPath("core/resources")]
    public class ResourceData {
        [JsonProperty("id")] public readonly string Id;
    }
}
