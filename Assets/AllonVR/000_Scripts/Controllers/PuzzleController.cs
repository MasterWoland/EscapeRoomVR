using System.Collections.Generic;
using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Controllers
{
    /// <summary>
    /// Keeps track of all puzzles
    /// </summary>
    public class PuzzleController : MonoBehaviour
    {
        [InjectID(Id = ID.E_MAGNET_CARD_ACTIVATED)] private PuzzleModelEvent _magnetCardActivatedEvent;
        [InjectID(Id = ID.E_PUSH_BUTTON_HIT)] private PuzzleModelEvent _pushButtonHitEvent;
        [InjectID(Id = ID.E_NUM_KEYPAD_CORRECT)] private PuzzleModelEvent _numKeypadCorrectEvent;
        [InjectID(Id = ID.E_LADDER_ACTIVATED)] private PuzzleModelEvent _ladderActivatedEvent;
        [InjectID(Id = ID.E_COLOR_KEYPAD_CORRECT)] private PuzzleModelEvent _colorKeypadCorrectEvent;
        [InjectID(Id = ID.E_PUZZLE_SOLVED)] private IntEvent _puzzleSolvedEvent_D;
        [InjectID(Id = ID.E_ALL_PUZZLES_SOLVED)] private NoParamEvent _allPuzzlesSolvedEvent_D;
        
        [SerializeField] private List<PuzzleModel> _puzzleModels = new List<PuzzleModel>();
        [SerializeField] private int _amountPuzzlesToBeSolved = 0; // MRA: temporarily exposed for testing purposes

        private void Awake()
        {
            DIBinder.Injector.Inject(this);
            DIBinder.Injector.InjectID(this);
            ResetPuzzleModels();
        }

        private void ResetPuzzleModels()
        {
            foreach (PuzzleModel model in _puzzleModels)
            {
                model.Reset();
            }

            _amountPuzzlesToBeSolved = _puzzleModels.Count;
        }

#region EVENTS
        private void OnEnable()
        {
            _magnetCardActivatedEvent.Handler += OnPuzzleSolved;
            _magnetCardActivatedEvent.RegisterListener(this);

            _pushButtonHitEvent.Handler += OnPuzzleSolved;
            _pushButtonHitEvent.RegisterListener(this);

            _numKeypadCorrectEvent.Handler += OnPuzzleSolved;
            _numKeypadCorrectEvent.RegisterListener(this);

            _ladderActivatedEvent.Handler += OnPuzzleSolved;
            _ladderActivatedEvent.RegisterListener(this);
            
            _colorKeypadCorrectEvent.Handler += OnPuzzleSolved;
            _colorKeypadCorrectEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _magnetCardActivatedEvent.Handler -= OnPuzzleSolved;
            _magnetCardActivatedEvent.UnregisterListener(this);

            _pushButtonHitEvent.Handler -= OnPuzzleSolved;
            _pushButtonHitEvent.UnregisterListener(this);

            _numKeypadCorrectEvent.Handler -= OnPuzzleSolved;
            _numKeypadCorrectEvent.UnregisterListener(this);
            
            _ladderActivatedEvent.Handler -= OnPuzzleSolved;
            _ladderActivatedEvent.UnregisterListener(this);

            _colorKeypadCorrectEvent.Handler -= OnPuzzleSolved;
            _colorKeypadCorrectEvent.UnregisterListener(this);
        }

        private void OnPuzzleSolved(PuzzleModel model)
        {
            // We need to check if we are not trying to set a solved puzzle to Solved again
            if(model.TrySetPuzzleSolved()) _amountPuzzlesToBeSolved--;

            if (_amountPuzzlesToBeSolved <= 0)
            {
                Debug.Log("[ PC ] --- No more puzzles to be solved ---");
                _allPuzzlesSolvedEvent_D?.Dispatch();
            }

            _puzzleSolvedEvent_D?.Dispatch(model.PuzzleIndex);
        }
#endregion
    }
}