// Jenni
using UnityEngine;

public class STGameManager : MonoBehaviour {
    [SerializeField] private GameState currentState = GameState.None;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject exitToMenuButton;
    [SerializeField] private GameObject restartGame;

    public GameState CurrentState {
        get { return this.currentState; }
        set { this.currentState = value; }
    }

    // GameStates
    // Intro - directions with start button
    // Playing - playing the game loop
    // Game Over - display score, restart game and exit to menu buttons
    #region MonoBehavior

    private void Start() {
        Subscribe();
        GameIntro();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }

    #endregion MonoBehavior

    #region Methods

    public void GameIntro() {
        currentState = GameState.Intro;
        STEventManager.Instance.BroadcastGameIntro();
        startButton.SetActive(true);
        exitToMenuButton.SetActive(false);
        restartGame.SetActive(false);
    }

    public void PlayGame() {
        currentState = GameState.Playing;
        startButton.SetActive(false);
        restartGame.SetActive(false);
        exitToMenuButton.SetActive(false);
    }

    public void EndGame() {
        currentState = GameState.GameOver;
        startButton.SetActive(false);
        exitToMenuButton.SetActive(true);
        restartGame.SetActive(true);
    }

    private void Subscribe() {
        Unsubscribe();
        STEventManager.Instance.OnGameStart += PlayGame;
        STEventManager.Instance.OnGameOver += EndGame;
    }

    private void Unsubscribe() {
        STEventManager.Instance.OnGameStart -= PlayGame;
        STEventManager.Instance.OnGameOver -= EndGame;
    }

    #endregion Methods
}