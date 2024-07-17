using System;
using AllonVR.Data;
using simpleDI.Injection;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Models
{
    [CreateAssetMenu(fileName = "NumAnswersModel", menuName = "Models/NumAnswersModel")]
    public class NumAnswersModel : ScriptableObject, IInjectable
    {
        public string[] CorrectAnswers;
        public string[] CurrentAnswers; // MRA: public only for testing purposes
        [SerializeField] private int _currentAnswerIndex = 0;

        private void OnEnable()
        {
            CurrentAnswers = new string[CorrectAnswers.Length];
            Reset();
        }

        private void OnDisable()
        {
            Reset();
        }

        private void Reset()
        {
            for (int i = 0; i < CurrentAnswers.Length; i++)
            {
                CurrentAnswers[i] = string.Empty;
            }

            _currentAnswerIndex = 0;
        }

        public bool IsCorrectAnswer()
        {
            for (int i = 0; i < CurrentAnswers.Length; i++)
            {
                if (!CurrentAnswers[i].Equals(CorrectAnswers[i])) return false;
            }

            return true;
        }

        public void ProcessButton(string buttonValue)
        {
            if (buttonValue.Equals(GlobalData.ERASE))
            {
                if (_currentAnswerIndex <= 0) return; // There is nothing to erase

                CurrentAnswers[--_currentAnswerIndex] = string.Empty;
            }
            else
            {
                if (_currentAnswerIndex >= CurrentAnswers.Length) 
                    _currentAnswerIndex = CurrentAnswers.Length - 1;
                CurrentAnswers[_currentAnswerIndex] = buttonValue;

                _currentAnswerIndex++;

                if (_currentAnswerIndex >= CurrentAnswers.Length)
                    _currentAnswerIndex = CurrentAnswers.Length;
            }
        }
    }
}