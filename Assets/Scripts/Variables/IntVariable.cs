// Jenni
// Modification of RoboRyanTron's Unite 2017's
// game architecture with scriptable objects
using UnityEngine;

namespace Variables {
    [CreateAssetMenu(fileName = "New Game Variable (Int)", menuName = "Game Variable/New Game Variable (Int)")]
    public class IntVariable : ScriptableObject {
        [SerializeField] private int intValue;

        public int IntValue {
            get { return this.intValue; }
            set { this.intValue = value; }
        }

        public IntVariable(int intValue) {
            this.intValue = intValue;
        }

        public static implicit operator int(IntVariable v) {
            return v.IntValue;
        }
    }
}