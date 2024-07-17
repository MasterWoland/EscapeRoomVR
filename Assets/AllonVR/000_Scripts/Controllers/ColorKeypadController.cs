using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using simpleDI.Injection;
using simpleDI.Injection.Allon;

namespace AllonVR.Controllers
{
    public class ColorKeypadController : KeypadController
    {
        [Inject] private ColorAnswersModel _model;
        [InjectID(Id = ID.E_COLOR_KEYPAD_CORRECT)] private PuzzleModelEvent _colorKeypadCorrectEvent_D;
        [InjectID(Id = ID.COLOR_KEYPAD_PUZZLE_MODEL)] private PuzzleModel _puzzleModel;
        
        protected override void Awake()
        {
            base.Awake();
            DIBinder.Injector.Inject(this);
        }

        protected override void Start()
        {
            base.Start();
            
            // _view.SetActive(true);
            // EnableButtonEvents(true);
        }

        protected override void OnPuzzleSolvedEvent(int puzzleNumber)
        {
            base.OnPuzzleSolvedEvent(puzzleNumber);

            int previousPuzzleNumber = _puzzleModel.PuzzleIndex - 1;
            if (puzzleNumber != previousPuzzleNumber) return;
            
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
            _colorKeypadCorrectEvent_D?.Dispatch(_puzzleModel);
        }
    }
}