using AllonVR.ScriptableObjects.Events;
using simpleDI.Injection;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace AllonVR.Components
{
    [System.Serializable]
    public class HapticSettings
    {
        public bool IsActive;
        [Range(0f, 1f)] public float Intensity = 0.6f;
        public float Duration = 0.2f;
    }

    public class XRPokeHapticFeedback : MonoBehaviour
    {
        [SerializeField] private XRDirectInteractor _directInteractor; // This has haptic enabled
        [SerializeField] private XRPokeInteractor _pokeInteractor; // To check against the originating event
        [Inject] private HapticImpulseEvent _hapticImpulseEvent;

        private void Awake()
        {
            DIBinder.Injector.Inject(this);
        }
        
#region EVENTS
        private void OnEnable()
        {
            _hapticImpulseEvent.Handler += OnPokeSelectEntered;
            _hapticImpulseEvent.RegisterListener(this);
        }
        private void OnDisable()
        {
            _hapticImpulseEvent.Handler -= OnPokeSelectEntered;
            _hapticImpulseEvent.UnregisterListener(this);
        }

        private void OnPokeSelectEntered(XRPokeInteractor pokeInteractor, float intensity, float duration)
        {
            // We don't want to send the haptic impulse to the wrong hand
            if (pokeInteractor == _pokeInteractor)
            {
                _directInteractor.SendHapticImpulse(intensity, duration);
            }
        }
#endregion
    }
}