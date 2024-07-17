using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using simpleDI.Injection;
using simpleDI.Injection.Allon;

namespace AllonVR.Controllers
{
    public class NumKeypadController : KeypadController
    {
        [Inject] private NumAnswersModel _model;
        [InjectID(Id = ID.E_BUTTON_PRESSED)] private StringEvent _buttonPressedEvent_D;
        [InjectID(Id = ID.NUM_KEYPAD_PUZZLE_MODEL)] private PuzzleModel _puzzleModel;
        [InjectID(Id = ID.E_NUM_KEYPAD_CORRECT)] private PuzzleModelEvent _numKeypadCorrectEvent_D;
        
        protected override void Awake()
        {
            base.Awake();
            DIBinder.Injector.Inject(this);
        }

        protected override void OnPuzzleSolvedEvent(int puzzleNumber)
        {
            base.OnPuzzleSolvedEvent(puzzleNumber);

            int previousPuzzleNumber = _puzzleModel.PuzzleIndex - 1;
            if (puzzleNumber != previousPuzzleNumber) return;
            
            // Debug.Log("[ NumKeypad ] We can START! ******");
            
            _view.SetActive(true);
            EnableButtonEvents(true);
            _buttonPressedEvent.Handler += OnButtonPressed;
            _buttonPressedEvent.RegisterListener(this);
        }

        protected override void OnButtonPressed(string value)
        {
            base.OnButtonPressed(value);

            _model.ProcessButton(value);

            if (!_model.IsCorrectAnswer()) return;
            
            // This puzzle is completed
            EnableButtonEvents(false);
            _buttonPressedEvent.Handler -= OnButtonPressed; // MRA: we should stop listening when this puzzle is finished
            _buttonPressedEvent.UnregisterListener(this);
            _numKeypadCorrectEvent_D?.Dispatch(_puzzleModel);
        }
    }
}