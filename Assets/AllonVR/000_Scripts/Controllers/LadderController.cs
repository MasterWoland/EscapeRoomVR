using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using AllonVR.Views;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Controllers
{
    public class LadderController : MonoBehaviour
    {
        [InjectID(Id = ID.E_LEVER_PULLED_EVENT)] private BooleanEvent _leverPulledEvent;
        [InjectID(Id = ID.E_LADDER_ACTIVATED)] private PuzzleModelEvent _ladderActivatedEvent_D;
        [InjectID(Id = ID.LADDER_ACTIVATED_PUZZLE_MODEL)] private PuzzleModel _puzzleModel;
        [SerializeField] private LadderView _view;
        
        private void Awake()
        {
            DIBinder.Injector.InjectID(this);
        }

        #region EVENTS
        private void OnEnable()
        {
            _view.OnLadderUp += OnLadderUp;
            _leverPulledEvent.Handler += OnLeverPulled;
            _leverPulledEvent.RegisterListener(this);
        }
        private void OnDisable()
        {
            _view.OnLadderUp -= OnLadderUp;
            _leverPulledEvent.Handler -= OnLeverPulled;
            _leverPulledEvent.UnregisterListener(this);
        }

        private void OnLadderUp()
        {
            _ladderActivatedEvent_D?.Dispatch(_puzzleModel);
        }

        private void OnLeverPulled(bool doActivate)
        {
            _view.Activate(doActivate);
        }
#endregion
    }
}