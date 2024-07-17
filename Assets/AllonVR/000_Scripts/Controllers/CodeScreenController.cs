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
    public class CodeScreenController : MonoBehaviour
    {
        [Inject] private PuzzleValues _puzzleValues;
        [InjectID(Id = ID.CODE_SCREEN_MODEL)] private ElectricityData _codeScreenModel;
        [InjectID(Id = ID.E_PUSH_BUTTON_HIT)] private PuzzleModelEvent _pushButtonHitEvent;
        [SerializeField] private CodeScreenView _view;
        
        private void Awake()
        {
            DIBinder.Injector.Inject(this);
            DIBinder.Injector.InjectID(this);
        }

        private void Start()
        {
            _view.Init(_codeScreenModel);
        }

#region EVENTS
        private void OnEnable()
        {
            _pushButtonHitEvent.Handler += OnActivateScreen;
            _pushButtonHitEvent.RegisterListener(this);
        }
        private void OnDisable()
        {
            _pushButtonHitEvent.Handler -= OnActivateScreen;
            _pushButtonHitEvent.UnregisterListener(this);
        }

        private void OnActivateScreen(PuzzleModel model)
        {
            // Debug.Log("[ CSC ] Activating Screen ****** "+_codeScreenModel.EnabledIntensity);
            _view.Activate(_codeScreenModel);
        }
#endregion
    }
}