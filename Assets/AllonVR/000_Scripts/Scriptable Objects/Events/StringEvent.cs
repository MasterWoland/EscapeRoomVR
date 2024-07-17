using UnityEngine;

namespace AllonVR.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "StringEvent", menuName = "Events/StringEvent")]
    public class StringEvent : BaseEvent
    {
        public delegate void EventHandler(string value);
        public EventHandler Handler;

        public void Dispatch(string value)
        {
            Handler?.Invoke(value);
        }
    }
}