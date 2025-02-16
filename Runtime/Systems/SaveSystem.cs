using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using VContainer;
using Yogi.RaidSurvival.Runtime.State;
using Yogi.RaidSurvival.Runtime.Utils;

namespace Yogi.RaidSurvival.Runtime.Systems {
    public class SaveSystem {
        private const string SaveFileExtension = ".sav";
        private const string CommonSaveName = "common";
        
        private readonly GameState _gameState;
        private readonly GameLogger _gameLogger;
        private readonly string _commonSaveName;

        [Inject]
        private SaveSystem(GameState gameState, GameLogger gameLogger) {
            _gameState = gameState;
            _gameLogger = gameLogger;

            _commonSaveName = $"{CommonSaveName}.{SaveFileExtension}";
        }
        
        public void Save() {
            var saveJson = JsonConvert.SerializeObject(_gameState);
            ES3.SaveRaw(saveJson, _commonSaveName);    
        }

        public void Load() {
            if (ES3.FileExists(_commonSaveName)) {
                var saveJson = ES3.LoadRawString(_commonSaveName);
                JsonConvert.PopulateObject(saveJson, _gameState);
            } else {
                _gameLogger.LogError($"{nameof(SaveSystem)}: Can't load save! Not found file with name: {_commonSaveName}");
            }
        }
        
        public async UniTask SaveAsync() {
            await UniTask.RunOnThreadPool(() => {
                var saveJson = JsonConvert.SerializeObject(_gameState);
                ES3.SaveRaw(saveJson, _commonSaveName);    
            });
        }
        
        public async UniTask LoadAsync() {
            if (ES3.FileExists(_commonSaveName)) {
                await UniTask.RunOnThreadPool(() => {
                    var saveJson = ES3.LoadRawString(_commonSaveName);
                    JsonConvert.PopulateObject(saveJson, _gameState);    
                });
            } else {
                _gameLogger.LogError($"{nameof(SaveSystem)}: Can't load save! Not found file with name: {_commonSaveName}");
            }
        }
    }
}
