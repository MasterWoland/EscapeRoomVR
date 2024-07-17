using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace AllonVR.ScriptableObjects.Events
{
    /// <summary>
    /// This event is necessary because the XRPokeInteractor does not allow for a haptic response
    /// </summary>
    [CreateAssetMenu(fileName = "HapticImpulseEvent", menuName = "Events/HapticImpulseEvent")]
    public class HapticImpulseEvent : BaseEvent
    {
        public delegate void EventHandler(XRPokeInteractor pokeInteractor, float intensity, float duration);
        public EventHandler Handler;

        public void Dispatch(XRPokeInteractor pokeInteractor,float intensity, float duration)
        {
            Handler?.Invoke(pokeInteractor, intensity, duration);
        }
    }
}