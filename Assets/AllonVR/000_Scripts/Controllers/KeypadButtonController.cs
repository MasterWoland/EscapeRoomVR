using AllonVR.Components;
using AllonVR.Data;
using AllonVR.Interfaces;
using AllonVR.ScriptableObjects.Events;
using simpleDI.Injection;
using simpleDI.Injection.Allon;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace AllonVR.Controllers
{
    public class KeypadButtonController : MonoBehaviour
    {
        public HapticSettings OnSelectEnter;
        [InjectID(Id = ID.E_BUTTON_PRESSED)] private StringEvent _buttonPressedEvent_D;
        [Inject] private HapticImpulseEvent _hapticImpulseEvent_D;
        [SerializeField] private XRSimpleInteractable _interactable;
        [SerializeField] private IPressable _view;
        [SerializeField] private string _buttonValue = string.Empty;
        
        private void Awake()
        {
            DIBinder.Injector.Inject(this);
            DIBinder.Injector.InjectID(this);

            if (_buttonValue == string.Empty) Debug.LogError("[ KeypadButtonController ] Button {" + this.name + "} has no value.");
        }

        private void Start()
        {
            _view = GetComponent<IPressable>();
        }

        public void EnableEventListening(bool doEnable)
        {
            if (doEnable) _interactable.selectEntered.AddListener(OnSelectButton);
            else _interactable.selectEntered.RemoveListener(OnSelectButton);
        }

        private void OnSelectButton(SelectEnterEventArgs arg0)
        {
            // MRA: add haptic response here
            _view.Press();
            _buttonPressedEvent_D?.Dispatch(_buttonValue);

            if (!OnSelectEnter.IsActive) return;
            
            _hapticImpulseEvent_D?.Dispatch(arg0.interactorObject as XRPokeInteractor,OnSelectEnter.Intensity, OnSelectEnter.Duration);
        }
    }
}