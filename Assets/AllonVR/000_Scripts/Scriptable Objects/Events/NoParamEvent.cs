using AllonVR.ScriptableObjects.Models;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "NoParamEvent", menuName = "Events/NoParamEvent")]
    public class NoParamEvent : BaseEvent
    {
        public delegate void EventHandler();
        public EventHandler Handler;

        public void Dispatch()
        {
            Handler?.Invoke();
        }
    }
}