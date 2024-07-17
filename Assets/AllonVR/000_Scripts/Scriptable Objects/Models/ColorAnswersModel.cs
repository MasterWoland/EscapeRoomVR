using System;
using simpleDI.Injection;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Models
{
    [CreateAssetMenu(fileName = "ColorAnswersModel", menuName = "Models/ColorAnswersModel")]
    public class ColorAnswersModel : ScriptableObject, IInjectable
    {
        public EmissiveTileModel[] TileModelArray;
        public Color[] ButtonColors;
        public string[] ButtonColorNames;
        public string[] CurrentAnswers; // MRA: public only for testing purposes
        private int _currentAnswerIndex = 0;

        private void OnEnable()
        {
            CurrentAnswers = new string[TileModelArray.Length];
            Reset();
        }

        private void OnDisable()
        {
            Reset();
            // CurrentAnswers = new string[TileModelArray.Length]; // Additional security
        }

        private void Reset()
        {
            for (int i = 0; i < CurrentAnswers.Length; i++)
            {
                CurrentAnswers[i] = string.Empty; //"None";
            }
            _currentAnswerIndex = 0;
        }

        public bool IsCorrectAnswer()
        {
            for (int i = 0; i < CurrentAnswers.Length; i++)
            {
                if (!CurrentAnswers[i].Equals(TileModelArray[i].ColorName))
                {
                    return false;
                }
            }
            return true;
        }

        public void ProcessButton(string buttonValue)
        {
            if (int.TryParse(buttonValue, out int colorIndex))
            {
                CurrentAnswers[_currentAnswerIndex] = ButtonColorNames[colorIndex];
                _currentAnswerIndex++;
            }
            else switch (buttonValue)
            {
                // MRA: global const
                case "Previous" when _currentAnswerIndex <= 0:
                    return;
                case "Previous":
                    _currentAnswerIndex--;
                    break;
                case "Next" when _currentAnswerIndex >= (CurrentAnswers.Length - 1):
                    return;
                case "Next":
                    _currentAnswerIndex++;
                    break;
                case "Erase":
                    CurrentAnswers[_currentAnswerIndex] = string.Empty;
                    break;
                default:
                    break;
            }
        }
    }

    [Serializable]
    public class EmissiveTileModel
    {
        public enum TileState
        {
            Default,
            Puzzle
        }

        public TileState Tile;
        public int Index; // check if this is necessary
        public int PuzzleIndex;
        public Color DefaultColor;
        public Color ActivatedColor;
        public float EmissionIntensity;
        public string ColorName = string.Empty;
    }
}