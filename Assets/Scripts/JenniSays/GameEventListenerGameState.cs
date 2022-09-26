// Jenni
using SOEvents.Events;
using UnityEngine.Events;

namespace SOEvents.Listeners {
    public class GameEventListenerGameState : BaseGameEventListener<GameState, GameEventGameState, UnityEvent<GameState>> {
    }
}