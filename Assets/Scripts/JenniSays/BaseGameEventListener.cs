using SOEvents.Events;
using UnityEngine;
using UnityEngine.Events;

namespace SOEvents.Listeners {
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
        IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T> {
        [SerializeField] private E gameEvent;
        [SerializeField] private UER response;

        #region Properties

        public E GameEvent { get => gameEvent; set => gameEvent = value; }
        public UER Response { get => response; set => response = value; }

        #endregion Properties

        #region MonoBehaviour

        private void OnEnable() {
            GameEvent?.RegisterListener(this);
        }

        private void OnDisable() {
            GameEvent?.UnregisterListener(this);
        }

        #endregion MonoBehaviour

        #region Class Methods

        public void OnEventRaised(T item) {
            Response?.Invoke(item);
        }

        #endregion Class Methods
    }
}