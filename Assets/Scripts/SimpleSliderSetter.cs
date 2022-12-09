// Jenni
// Modification of RoboRyanTron's Unite 2017's
// game architecture with scriptable objects
using UnityEngine;
using UnityEngine.UI;

public class SimpleSliderSetter : MonoBehaviour {

    // tutorial has this as public, does it really need to be?
    [SerializeField] private Slider slider;

    [SerializeField] private Variables.FloatVariable variable;

    private void Update() {
        if (slider != null && variable != null) {
            slider.value = variable.Value;
        }
    }
}