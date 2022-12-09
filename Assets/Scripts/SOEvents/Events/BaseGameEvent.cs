using System.Collections.Generic;
using SOEvents.Listeners;
using UnityEngine;

namespace SOEvents.Events {
    public abstract class BaseGameEvent<T> : ScriptableObject {
        private readonly List<IGameEventListener<T>> listeners = new List<IGameEventListener<T>>();

        public void Raise(T item) {
            for(int i = listeners.Count - 1; i >= 0; i -= 1) {
                listeners[i].OnEventRaised(item);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener) {
            if(!listeners.Contains(listener)) {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(IGameEventListener<T> listener) {
            while(listeners.Contains(listener)) {
                listeners.Remove(listener);
            }
        }
    }
}