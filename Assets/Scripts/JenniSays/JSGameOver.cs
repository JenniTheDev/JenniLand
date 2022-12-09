// Jenni
using TMPro;
using UnityEngine;
using Variables;

namespace JenniSays {
    public class JSGameOver : MonoBehaviour {
        [SerializeField] private GameManager gameManager;

        // [SerializeField] private AudioSource speaker;
        // [SerializeField] private AudioClip gameOverSound;
        [SerializeField] private IntVariable score;

        [SerializeField] private string finalScore;
        [SerializeField] private TMP_Text finalScoreText;
        [SerializeField] private TMP_Text highestScoreText;
        private int highestScore = 0;

        public void GameOver(GameState currentState) {
            if (currentState == GameState.GameOver) {
                DisplayFinalScore();
                DisplayHighScores();
                // PlaySound();
            }
        }

        private void PlaySound() {
            // speaker.clip = gameOverSound;
            // speaker.Play();
        }

        private void DisplayHighScores() {
            if (score.IntValue > highestScore) {
                highestScore = score.IntValue;
            }
            highestScoreText.text = $"Your best score is {highestScore}";
        }

        private void DisplayFinalScore() {
            finalScore = score.IntValue.ToString();
            finalScoreText.text = $"Final Score {finalScore}";
        }
    }
}