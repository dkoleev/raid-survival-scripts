﻿using System.Collections.Generic;

namespace RaidSurvival.Runtime.Data.Core {
    public class CoreData {
        public Dictionary<string, ResourceData> Resources { get; private set; }
        internal void Load(DataLoader loader) {
            Resources = loader.DeserializeStringKeyDictionary<ResourceData>();
        }
    }
}
