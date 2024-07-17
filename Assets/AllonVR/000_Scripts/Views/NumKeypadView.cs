using AllonVR.Data;
using AllonVR.Interfaces;
using UnityEngine;

namespace AllonVR.Views
{
    public class NumKeypadView : MonoBehaviour, IShowable
    {
        [SerializeField] private GameObject[] _entries;
        [SerializeField] private GameObject _buttonParent; 
        [SerializeField] private GameObject _answerParent; 
        private int _currentEntryIndex = 0;
        private int _dotIndex;
        private int _numChildObjects;
        
        private void Start()
        {
            _numChildObjects = _entries[_currentEntryIndex].transform.childCount; // All Entry GameObjects have the same amount of Child Objects
            _dotIndex = _numChildObjects - 1; // Dot is the last Child Object
        }

        public void SetActive(bool doActivate)
        {
            _buttonParent.SetActive(doActivate);
            _answerParent.SetActive(doActivate);
        }
        
        public void ShowEntry(string entry)
        {
            if (int.TryParse(entry, out int activateIndex))
            {
                ActivateCorrectChildObject(activateIndex);
            }
            else
            {
                if (entry.Equals(GlobalData.DOT))
                {
                    ActivateCorrectChildObject(_dotIndex);
                }
                else ErasePreviousEntry();
            }
        }

        private void ActivateCorrectChildObject(int activateIndex)
        {
            if (_currentEntryIndex >= _entries.Length) return;
            
            for (int i = 0; i < _numChildObjects; i++)
            {
                _entries[_currentEntryIndex].transform.GetChild(i).gameObject.SetActive(i == activateIndex);
            }

            _currentEntryIndex++;
        }

        private void ErasePreviousEntry()
        {
            if (_currentEntryIndex <= 0) return; // We cannot erase
            
            _currentEntryIndex--;
            ActivateCorrectChildObject(_dotIndex);
            _currentEntryIndex--;
        }
    }
}