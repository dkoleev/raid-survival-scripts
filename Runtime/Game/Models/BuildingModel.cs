using RaidSurvival.Runtime.Data;
using VContainer;

namespace RaidSurvival.Runtime.Game.Models {
    public class BuildingModel {
        public float Durability { get; set; }

        [Inject]
        private BuildingModel(IDataService dataService) {
            var data = dataService.GetData();
        }
    }
}
