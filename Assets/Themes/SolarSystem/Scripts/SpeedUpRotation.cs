using UnityEngine;

namespace UnityBase.SolarSystem
{
    public class SpeedUpRotation : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 1000)]
        private float rotationSpeedMultiplier = 1.0f;

        private Rect label = new Rect();
        private Rect slider;

        public Rect Label
        {
            get => label;
            set
            {
                label = value;
            }
        }

        public Rect Slider
        {
            get => slider;
            set
            {
                slider = value;
            }
        }
        internal float RotationSpeedMultiplier
        {
            get => rotationSpeedMultiplier;
        }

        private void Awake()
        {
            Label = new Rect(Screen.width * 0.6f / 2, Screen.height * 0.9f, 250, 20);
            Slider = new Rect(Screen.width * 0.9f / 2, Screen.height * 0.915f, 250, 20);
        }

        private void OnGUI()
        {
            GUI.Label(Label, "Change speed: ");
            GUIStyle style = new GUIStyle();
            GUI.color = Color.white;
            rotationSpeedMultiplier = GUI.HorizontalSlider(Slider, rotationSpeedMultiplier, 1, 1000);
        }
    }
}
