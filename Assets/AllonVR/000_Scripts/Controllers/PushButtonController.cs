using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using AllonVR.Views;
using simpleDI.Injection;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Controllers
{
    /// <summary>
    /// We need a Rigidbody because this way we can listen to the OnTriggerEnter in a Child Object
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PushButtonController : MonoBehaviour
    {
        [Inject] private PuzzleValues _puzzleValues;
        [InjectID(Id = ID.ELECTRICITY_DATA)] private ElectricityData _electricityData;
        [InjectID(Id = ID.PUSH_BUTTON_PUZZLE_MODEL)] private PuzzleModel _pushButtonPuzzleModel;
        [InjectID(Id = ID.E_MAGNET_CARD_ACTIVATED)] private PuzzleModelEvent _magnetCardActivatedEvent;
        [InjectID(Id = ID.E_PUSH_BUTTON_HIT)] private PuzzleModelEvent _pushButtonHitEvent_D;
        [SerializeField] private PushButtonView _view;
        private bool _canHitPushButton = false;
        
        private void Awake()
        {
            DIBinder.Injector.Inject(this);
            DIBinder.Injector.InjectID(this);
        }

        private void Start()
        {
            _view.Init(_electricityData);
        }

#region EVENTS
        private void OnEnable()
        {
            _magnetCardActivatedEvent.Handler += OnActivatePower;
            _magnetCardActivatedEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _magnetCardActivatedEvent.Handler -= OnActivatePower;
            _magnetCardActivatedEvent.UnregisterListener(this);
        }

        private void OnActivatePower(PuzzleModel model)
        {
            _view.Activate(_electricityData);
            _canHitPushButton = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Debug.Log("[ PBC ] Collision Enter "+collision.rigidbody.velocity.sqrMagnitude);
            if (!_canHitPushButton)
            {
                Debug.Log("[ ] cannot hit push button yet ____ ");
                return;
            }
            
            if (_pushButtonPuzzleModel.IsSolved)
            {
                Debug.Log(" ____ is already solved ____");
                return;
            }
            
            if (collision.rigidbody.velocity.sqrMagnitude > _puzzleValues.PUSH_BUTTON_MINIMAL_VELOCITY)
            {
                // Debug.Log("[ PBC ] *******  HIT  !!!!!");
                _view.HandlePush();
                // _pushButtonPuzzleModel.SetPuzzleSolved();
                _pushButtonHitEvent_D?.Dispatch(_pushButtonPuzzleModel);
            }
        }
#endregion
    }
}