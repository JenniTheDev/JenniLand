// Jenni
using TMPro;
using UnityEngine;
using Variables;

public class JSScore : MonoBehaviour {
    [SerializeField] private IntVariable score;
    [SerializeField] private TMP_Text scoreText;

    private void Update() {
        scoreText.text = $"Level {score.IntValue.ToString()}";
    }
}