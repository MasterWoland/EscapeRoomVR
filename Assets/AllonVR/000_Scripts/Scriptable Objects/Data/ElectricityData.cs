using simpleDI.Injection;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Models
{
    [CreateAssetMenu(fileName = "ElectricityData", menuName = "Data/ElectricityData")]
    public class ElectricityData : ScriptableObject, IInjectable
    {
        public Color DisabledColor;
        public Color EnabledColor;
        public float EnabledIntensity = 2;
    }
}