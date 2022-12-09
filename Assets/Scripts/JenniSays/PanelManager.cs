// Jenni
using UnityEngine;

namespace JenniSays {
    public class PanelManager : MonoBehaviour {
        [SerializeField] private GameObject intro;
        [SerializeField] private GameObject playing;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameManager gameManager;

        #region MonoBehaviour

        private void Start() {
            ResetPanels();
            gameManager.PlayIntro();
        }

        #endregion MonoBehaviour

        public void ChangePanel(GameState currentState) {
            ResetPanels();
            switch (currentState) {
                case GameState.Intro:
                    intro.SetActive(true);
                    break;

                case GameState.Playing:
                    playing.SetActive(true);
                    break;

                case GameState.GameOver:
                    gameOver.SetActive(true);
                    break;

                default:
                    break;
            }
        }

        private void ResetPanels() {
            intro.SetActive(false);
            playing.SetActive(false);
            gameOver.SetActive(false);
        }
    }
}