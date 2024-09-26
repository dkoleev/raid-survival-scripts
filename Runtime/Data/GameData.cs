﻿using Yogi.RaidSurvival.Runtime.Data.Core;

namespace Yogi.RaidSurvival.Runtime.Data {
    public class GameData {
        public CoreData Core { get; private set; } = new();

        public void Load() {
            var loader = new DataLoader();
            Core.Load(loader);
        }
    }
}
