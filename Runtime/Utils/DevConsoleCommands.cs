using JetBrains.Annotations;
using UnityEngine;
using Yogi.UnityDevConsole.Scripts.Runtime;

namespace Yogi.RaidSurvival.Runtime.Utils {
    [UsedImplicitly]
    public static class DevConsoleCommands {
        [DevConsoleCommand("echo")]
        public static void Echo(string text) {
            Debug.Log(text);
        }

        private static void Test() {
            
        }
    }
}
