using AllonVR.Components;
using AllonVR.Interfaces;
using AllonVR.ScriptableObjects.Models;
using simpleDI.Injection;
using UnityEngine;

namespace AllonVR.Views
{
    public class ColorKeypadView : MonoBehaviour, IShowable
    {
        [Inject] private ColorAnswersModel _model;
        [SerializeField] private GameObject _answerParent;
        [SerializeField] private Color _currentColor;
        [SerializeField] private SpriteRenderer[] _outerEntries;
        [SerializeField] private SpriteRenderer[] _innerEntries;
        private int _currentEntryIndex = 0; // to parent class
        private Color _defaultColor;
        // private int _numChildObjects; // to parent class

        private void Awake()
        {
            DIBinder.Injector.Inject(this);
        }

        private void Start()
        {
            // _numChildObjects = _outerEntries[_currentEntryIndex].transform.childCount; // All Entry GameObjects have the same amount of Child Objects

            _defaultColor = _outerEntries[_currentEntryIndex].color;
            _outerEntries[_currentEntryIndex].color = _currentColor;
        }

        public void SetActive(bool doActivate)
        {
            _answerParent.SetActive(doActivate);
        }

        public void ShowEntry(string entry)
        {
            if (int.TryParse(entry, out int colorIndex))
            {
                ShowColor(colorIndex);
            }
            else
            {
                if (entry == "Previous") // MRA: global const
                {
                    if (_currentEntryIndex <= 0) return;

                    _outerEntries[_currentEntryIndex].color = _defaultColor;
                    _outerEntries[--_currentEntryIndex].color = _currentColor;
                }
                else if (entry == "Next") // MRA: global const
                {
                    if (_currentEntryIndex >= (_innerEntries.Length - 1)) return;
                    _outerEntries[_currentEntryIndex].color = _defaultColor;
                    _outerEntries[++_currentEntryIndex].color = _currentColor;
                }
                else EraseEntry();
            }
        }

        private void EraseEntry()
        {
            // _outerEntries[_currentEntryIndex].color = _currentColor;
            _innerEntries[_currentEntryIndex].color = _defaultColor;
        }

        private void ShowColor(int colorIndex)
        {
            _outerEntries[_currentEntryIndex].color = _defaultColor;
            _innerEntries[_currentEntryIndex].color = _model.ButtonColors[colorIndex];

            if (_currentEntryIndex >= (_outerEntries.Length - 1)) return;
            _outerEntries[++_currentEntryIndex].color = _currentColor;
            // if (_currentEntryIndex >= _innerEntries.Length) Debug.LogError("[ ColorKeypadView ] Reached the last Entry");
        }
    }
}