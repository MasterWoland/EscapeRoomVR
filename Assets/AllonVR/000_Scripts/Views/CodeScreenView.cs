using AllonVR.Data;
using AllonVR.ScriptableObjects.Models;
using Pixelplacement;
using UnityEngine;

namespace AllonVR.Views
{
    public class CodeScreenView : MonoBehaviour
    {
        [SerializeField] private Renderer _screenRenderer;

        public void Init(ElectricityData data)
        {
            _screenRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.DisabledColor * 0);
        }

        public void Activate(ElectricityData data)
        {
            Tween.ShaderColor (_screenRenderer.material, "_EmissionColor", data.EnabledColor * data.EnabledIntensity, 2.5f, 0, Tween.EaseIn);

            // _screenRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.EnabledColor * data.EnabledIntensity);
        }
    }
}