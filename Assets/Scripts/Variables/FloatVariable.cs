// Jenni
// Modification of RoboRyanTron's Unite 2017's
// game architecture with scriptable objects
using UnityEngine;

namespace Variables {
    [CreateAssetMenu(fileName = "New Game Variable (Float)", menuName = "Game Variable/New Game Variable (float)")]
    public class FloatVariable : ScriptableObject {
        public float Value;

        public void SetValue(float value) {
            Value = value;
        }

        public void SetValue(FloatVariable value) {
            Value = value.Value;
        }

        public void ApplyChange(float amount) {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount) {
            Value += amount.Value;
        }
    }
}