// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace JenniSays {
    public class JSGameLogic : MonoBehaviour {

        private enum GameMode {
            NONE, PlayingBack, Receiving
        }

        [SerializeField]
        private int gameLevel = 1;

        [SerializeField]
        private IntVariable score;

        [SerializeField]
        private int initialLevel;

        [SerializeField]
        private int resetLevel;

        [SerializeField]
        private int startBonusLevel;

        [SerializeField]
        private float speedIncrease = 0.2f;

        [SerializeField]
        private List<JSButton> gameButtons;

        [SerializeField]
        private List<JSButton> bonusButtons;

        [SerializeField]
        private AudioSource speaker;

        private List<JSButton> orderToMatch;

        private int currentIndex;
        private float pauseBetweenLevels = 1.0f;

        private GameMode currentMode = GameMode.NONE;

        [SerializeField] private GameManager gameManager;

        private void Start() {
            ResetGame();
        }

        private void Update() {
        }

        private void ResetGame() {
            currentMode = GameMode.PlayingBack;
            orderToMatch = new List<JSButton>();
            gameLevel = initialLevel;
            currentIndex = 0;
            score.IntValue = 1;
            RemoveBonusButtons();
        }

        private void RemoveBonusButtons() {
            foreach (var button in bonusButtons) {
                button.gameObject.SetActive(false);
                gameButtons.Remove(button);
            }
        }

        public void StartGame(GameState currentState) {
            if (currentState == GameState.Playing) {
                AddRandomButton();
                StartCoroutine(PlayButtonSequence(orderToMatch, speedIncrease));
            }
        }

        private void AddRandomButton() {
            int buttonToAdd = UnityEngine.Random.Range(0, gameButtons.Count);
            orderToMatch.Add(gameButtons[buttonToAdd]);
        }

        private void AddRandomButtons(int numToAdd) {
            for (int i = 0; i < numToAdd; i++) {
                AddRandomButton();
            }
        }

        private void GameOver() {
            gameManager.EndGame();
            ResetGame();
        }

        private IEnumerator PlayButtonSequence(List<JSButton> buttons, float pauseTime) {
            currentMode = GameMode.PlayingBack;
            WaitForSeconds waitTime = new WaitForSeconds(pauseTime);
            yield return new WaitForSeconds(pauseBetweenLevels);
            foreach (var button in buttons) {
                ActivateButton(button);
                yield return waitTime;
            }
            currentMode = GameMode.Receiving;
        }

        public void ActivateButton(JSButton selectedButton) {
            //if (speaker.isPlaying || selectedButton.ButtonAnimation.isPlaying) {
            //    Debug.Log("Attempted to activate JSButton while already active");
            //    return;
            //}
            selectedButton.ButtonAnimation.Play();
            PlayButtonAudio(selectedButton);
            if (this.currentMode == GameMode.Receiving && currentIndex < orderToMatch.Count) {
                selectedButton.ButtonAnimation.Play();
                PlayButtonAudio(selectedButton);
                if (selectedButton == orderToMatch[currentIndex]) {
                    currentIndex++;
                } else {
                    GameOver();
                }
            }
            if (currentIndex == orderToMatch.Count && currentIndex != 0) {
                NextLevel();
            }
        }

        private void NextLevel() {
            if (gameLevel == startBonusLevel) {
                AddBonusButtons();
            }
            currentIndex = 0;
            gameLevel++;
            // score.SetValue(gameLevel);
            score.IntValue = gameLevel;
            currentMode = GameMode.PlayingBack;
            pauseBetweenLevels *= speedIncrease;
            gameManager.PlayGame();
        }

        private void AddBonusButtons() {
            foreach (var button in bonusButtons) {
                button.gameObject.SetActive(true);
                gameButtons.Add(button);
            }
        }

        private void PlayButtonAudio(JSButton buttonToPlay) {
            speaker.clip = buttonToPlay.ButtonAudioClip;
            speaker.Play();
        }
    }
}