// Jenni
using SOEvents.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Managers/GameManager")]
public class GameManager : ScriptableObject {
    [SerializeField] private GameState currentState = GameState.None;
    [SerializeField] private GameEventGameState onGameStateChange;

    public GameState CurrentState {
        get { return this.currentState; }
    }

    #region Methods

    public void PlayIntro() {
        currentState = GameState.Intro;
        BroadcastGameStateChange();
    }

    public void PlayGame() {
        currentState = GameState.Playing;
        BroadcastGameStateChange();
    }

    public void EndGame() {
        currentState = GameState.GameOver;
        BroadcastGameStateChange();
    }

    private void BroadcastGameStateChange() {
        onGameStateChange.Raise(this.currentState);
    }

    #endregion Methods
}