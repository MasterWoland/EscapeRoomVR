namespace AllonVR.Data
{
    /// <summary>
    /// ID's used for Dependency Injection
    /// </summary>
    public struct ID
    {

        // Data
        public const string ELECTRICITY_DATA = "ElectricityData";
        public const string CODE_SCREEN_MODEL = "CodeScreenModel";
        public const string MAGNET_CARD_PUZZLE_MODEL = "MagnetCardPuzzleModel";
        public const string PUSH_BUTTON_PUZZLE_MODEL = "PushButtonPuzzleModel";
        public const string NUM_KEYPAD_PUZZLE_MODEL = "NumKeypadPuzzleModel";
        public const string LADDER_ACTIVATED_PUZZLE_MODEL = "LadderActivatedPuzzleModel";
        public const string COLOR_KEYPAD_PUZZLE_MODEL = "ColorKeypadPuzzleModel";
        
        // Classes
        
        // Events
        public const string E_MAGNET_CARD_ACTIVATED = "MagnetCardActivatedEvent";
        public const string E_PUSH_BUTTON_HIT = "PushButtonHitEvent";
        public const string E_NUM_KEYPAD_CORRECT = "NumKeypadCorrectEvent";
        public const string E_LADDER_ACTIVATED = "LadderActivatedEvent";
        public const string E_COLOR_KEYPAD_CORRECT = "ColorKeypadCorrectEvent";
        public const string E_PUZZLE_SOLVED = "PuzzleSolvedEvent";
        public const string E_BUTTON_PRESSED = "ButtonPressedEvent";
        public const string E_LEVER_PULLED_EVENT = "LeverPulledEvent";
        public const string E_ALL_PUZZLES_SOLVED = "AllPuzzlesSolvedEvent";
    }
}