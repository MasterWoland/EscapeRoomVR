using AllonVR.ScriptableObjects.Models;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "PuzzleModelEvent", menuName = "Events/PuzzleModelEvent")]
    public class PuzzleModelEvent : BaseEvent
    {
        public delegate void EventHandler(PuzzleModel model);
        public EventHandler Handler;

        public void Dispatch(PuzzleModel model)
        {
            Handler?.Invoke(model);
        }
    }
}