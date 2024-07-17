using UnityEngine;

namespace AllonVR.Data
{
    public class GlobalData
    {
        public static readonly int BASE_COLOR = Shader.PropertyToID("_BaseColor");
        public static readonly int EMISSION_COLOR = Shader.PropertyToID("_EmissionColor");
        public static readonly string ERASE = "Erase";
        public static readonly string PREVIOUS = "Previous";
        public static readonly string NEXT = "Next";
        public static readonly string DOT = ".";
    }
}