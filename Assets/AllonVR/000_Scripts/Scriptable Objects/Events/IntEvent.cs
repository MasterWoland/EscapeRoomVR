using UnityEngine;

namespace AllonVR.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "IntEvent", menuName = "Events/IntEvent")]
    public class IntEvent : BaseEvent
    {
        public delegate void EventHandler(int value);
        public EventHandler Handler;

        public void Dispatch(int value)
        {
            Handler?.Invoke(value);
        }
    }
}