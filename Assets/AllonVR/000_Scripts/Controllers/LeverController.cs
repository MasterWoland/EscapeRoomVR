using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using AllonVR.Views;
using simpleDI.Injection.Allon;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

namespace AllonVR.Controllers
{
    public class LeverController : MonoBehaviour
    {
        [InjectID(Id = ID.E_NUM_KEYPAD_CORRECT)] private PuzzleModelEvent _numKeypadCorrectEvent;
        [InjectID(Id = ID.ELECTRICITY_DATA)] private ElectricityData _electricityData;
        [InjectID(Id = ID.E_LEVER_PULLED_EVENT)] private BooleanEvent _leverPulledEvent_D;
        [SerializeField] private LeverView _view;
        [SerializeField] private XRLever _lever;

        private void Awake()
        {
            // DIBinder.Injector.Inject(this);
            DIBinder.Injector.InjectID(this);
        }

        private void Start()
        {
            _lever.enabled = false;
            _view.Init(_electricityData);
        }

#region EVENTS
        private void OnEnable()
        {
            _numKeypadCorrectEvent.Handler += OnActivatePower;
            _numKeypadCorrectEvent.RegisterListener(this);
        }

        private void OnActivatePower(PuzzleModel model)
        {
            _lever.enabled = true;
            _lever.onLeverActivate.AddListener(OnLeverActivate);
            _lever.onLeverDeactivate.AddListener(OnLeverDeactivate);
            _view.Activate(_electricityData);
        }

        private void OnLeverActivate()
        {
            _leverPulledEvent_D?.Dispatch(true);
        }

        private void OnLeverDeactivate()
        {
            _leverPulledEvent_D?.Dispatch(false);
        }
#endregion
    }
}