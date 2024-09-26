using System;
using JetBrains.Annotations;

namespace Yogi.RaidSurvival.Runtime.Data {
    [UsedImplicitly]
    internal class DataPathAttribute : Attribute {
        public string DataPath { get; }

        public DataPathAttribute(string dataPath) {
            DataPath = dataPath;
        }
    }
}
