using AllonVR.Data;
using AllonVR.ScriptableObjects.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using simpleDI.Injection;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Components
{

    public class DIBinder : MonoBehaviour
    {
        public static Injector Injector;

        [Header("Data")]
        [SerializeField] private ElectricityData _electricityData;
        [SerializeField] private ElectricityData _codeScreenModel;
        [SerializeField] private PuzzleModel _magnetCardPuzzleModel;
        [SerializeField] private PuzzleModel _pushButtonPuzzleModel;
        [SerializeField] private PuzzleModel _numKeypadPuzzleModel;
        [SerializeField] private PuzzleModel _ladderActivatedPuzzleModel;
        [SerializeField] private PuzzleModel _colorKeypadPuzzleModel;
        [SerializeField] private ColorAnswersModel _colorAnswersModel;
        [SerializeField] private NumAnswersModel _numAnswersModel;
        [SerializeField] private PuzzleValues _puzzleValues;
        
        [Header("Events")]
        [SerializeField] private PuzzleModelEvent _magnetCardActivatedEvent;
        [SerializeField] private PuzzleModelEvent _pushButtonHitEvent;
        [SerializeField] private PuzzleModelEvent _numKeypadCorrectEvent;
        [SerializeField] private PuzzleModelEvent _ladderActivatedEvent;
        [SerializeField] private PuzzleModelEvent _colorKeypadCorrectEvent;
        [SerializeField] private IntEvent _puzzleSolvedEvent;
        [SerializeField] private StringEvent _buttonPressedEvent;
        [SerializeField] private BooleanEvent _leverPulledEvent;
        [SerializeField] private NoParamEvent _allPuzzlesSolvedEvent;
        [SerializeField] private HapticImpulseEvent _hapticImpulseEvent;
        
        private void Awake()
        {
            // DontDestroyOnLoad(this);
            Injector = new Injector();
            Bind();
        }

        private void Bind()
        {
            // MRA: order is important
            
            // Data
            Injector.BindWithId(_electricityData, ID.ELECTRICITY_DATA);
            Injector.BindWithId(_codeScreenModel, ID.CODE_SCREEN_MODEL);
            Injector.BindWithId(_magnetCardPuzzleModel, ID.MAGNET_CARD_PUZZLE_MODEL);
            Injector.BindWithId(_pushButtonPuzzleModel, ID.PUSH_BUTTON_PUZZLE_MODEL);
            Injector.BindWithId(_numKeypadPuzzleModel, ID.NUM_KEYPAD_PUZZLE_MODEL);
            Injector.BindWithId(_ladderActivatedPuzzleModel, ID.LADDER_ACTIVATED_PUZZLE_MODEL);
            Injector.BindWithId(_colorKeypadPuzzleModel, ID.COLOR_KEYPAD_PUZZLE_MODEL);
            Injector.Bind(_colorAnswersModel);
            Injector.Bind(_numAnswersModel);
            Injector.Bind(_puzzleValues);
            Injector.Bind(_hapticImpulseEvent);
            // Injector.Bind(new PushButtonData());
            
            // Classes
            
            // Events
            Injector.BindWithId(_magnetCardActivatedEvent, ID.E_MAGNET_CARD_ACTIVATED);
            Injector.BindWithId(_pushButtonHitEvent, ID.E_PUSH_BUTTON_HIT);
            Injector.BindWithId(_numKeypadCorrectEvent, ID.E_NUM_KEYPAD_CORRECT);
            Injector.BindWithId(_ladderActivatedEvent, ID.E_LADDER_ACTIVATED);
            Injector.BindWithId(_colorKeypadCorrectEvent, ID.E_COLOR_KEYPAD_CORRECT);
            Injector.BindWithId(_puzzleSolvedEvent, ID.E_PUZZLE_SOLVED);
            Injector.BindWithId(_buttonPressedEvent, ID.E_BUTTON_PRESSED);
            Injector.BindWithId(_leverPulledEvent, ID.E_LEVER_PULLED_EVENT);
            Injector.BindWithId(_allPuzzlesSolvedEvent, ID.E_ALL_PUZZLES_SOLVED);
        }
    }
}
