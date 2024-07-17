using System.Collections;
using System.Collections.Generic;
using simpleDI.Injection;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Events
{
    /// <summary>
    /// Base class for Events.
    /// Contains the Registration logic.
    /// </summary>
    public abstract class BaseEvent : ScriptableObject, IInjectable
    {
        protected List<MonoBehaviour> _listeners = new List<MonoBehaviour>();

        public void RegisterListener(MonoBehaviour listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(MonoBehaviour listener)
        {
            _listeners.Remove(listener);
        }

        public bool IsListenerRegistered(MonoBehaviour listener)
        {
            return _listeners.Contains(listener);
        }
    }
}