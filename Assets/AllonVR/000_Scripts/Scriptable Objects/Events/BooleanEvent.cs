using AllonVR.ScriptableObjects.Models;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "BooleanEvent", menuName = "Events/BooleanEvent")]
    public class BooleanEvent : BaseEvent
    {
        public delegate void EventHandler(bool value);
        public EventHandler Handler;

        public void Dispatch(bool value)
        {
            Handler?.Invoke(value);
        }
    }
}