using Unity.Collections;

namespace RaidSurvival.Runtime.Experiments {
    public class Native {
        private NativeArray<int> _nativeArray;

        public Native(int size) {
            _nativeArray = new NativeArray<int>(size, Allocator.Persistent);
        }

        public void Update() {
        }
    }
}
