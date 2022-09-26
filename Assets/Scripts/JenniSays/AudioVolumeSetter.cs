// Jenni
// Modification of RoboRyanTron's Unite 2017's
// game architecture with scriptable objects
using UnityEngine;
using UnityEngine.Audio;

namespace Variables {
    public class AudioVolumeSetter : MonoBehaviour {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private string parameterName = "";
        [SerializeField] private FloatVariable variable;
        private float dB = 0.0f;

        private void Update() {
            dB = variable.Value > 0.0f ?
                20.0f * Mathf.Log10(variable.Value) :
                -80.0f;

            mixer.SetFloat(parameterName, dB);

        }
    }
}