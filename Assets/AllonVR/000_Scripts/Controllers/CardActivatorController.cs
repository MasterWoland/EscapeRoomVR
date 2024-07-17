using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using AllonVR.Views;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Controllers
{
    /// <summary>
    /// We need a Rigidbody because this way we can listen to the OnTriggerEnter in a Child Object
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class CardActivatorController : MonoBehaviour
    {
        [InjectID(Id = ID.ELECTRICITY_DATA)] private ElectricityData _electricityData; 
        [InjectID(Id = ID.E_MAGNET_CARD_ACTIVATED)] private PuzzleModelEvent _magnetCardActivatedEvent_D;
        [InjectID(Id = ID.MAGNET_CARD_PUZZLE_MODEL)] private PuzzleModel _magnetCardPuzzleModel;
        [SerializeField] private CardActivatorView _view;
        
        private void Awake()
        {
            DIBinder.Injector.Inject(this);
            DIBinder.Injector.InjectID(this);
        }

        private void Start()
        {
            _view.Init(_electricityData);
        }

        private void OnTriggerEnter(Collider other)
        {
            // compare tag
            if (!other.CompareTag(_magnetCardPuzzleModel.Tag)) return;
            
            _view.Activate(_electricityData);
            _magnetCardActivatedEvent_D?.Dispatch(_magnetCardPuzzleModel);
        }
    }
}