using System;
using UnityEngine;

namespace RaidSurvival.Runtime.Experiments {
    public class Ideas {
        private void AllocationArrayOnStack() {
            //Use this only inside one function for short live
            Span<int> points = stackalloc int[4];
        }

        private void QuickSort(int[] array) {
            Span<int> stack = stackalloc int[array.Length];
            array.CopyTo(stack);
            //Not we can perform sorting operations on stack
            //It's automatically will be fried when the method returns
        }

        private void GetStructAsReadOnyRef(in Hero hero) {
            Debug.Log(hero.Name);
        }
    }
    
    public ref struct Hero {
        public string Name;
    }

    public unsafe struct FixedBuffer {
        public fixed int Data[8];
    }

    //use byte instead of int for optimization. Be aware because byte can hold only 0..256
    public enum EnemyType : byte {
        Dragon,
        Orc
    }
}
