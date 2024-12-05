using VContainer;
using Yogi.RaidSurvival.Runtime.Data;

namespace Yogi.RaidSurvival.Runtime.Game.Models {
    public class BuildingModel {
        public float Durability { get; set; }

        [Inject]
        private BuildingModel(IDataService dataService) {
            var data = dataService.GetData();
        }
    }
}
