using UnityEngine;

namespace UnityBase.SolarSystem
{
    public class PlanetRotation : MonoBehaviour
    {
        [SerializeField]
        private GameObject GUISlider;
        [SerializeField]
        private float RotationSpeed = 1.0f;
        private float SpeedMultiplier = 1.0f;
        void Update()
        {
            SpeedMultiplier = GUISlider.GetComponent<SpeedUpRotation>().RotationSpeedMultiplier;
            float angle = ((float)(1.0 / RotationSpeed) * Time.deltaTime) * SpeedMultiplier;
            transform.Rotate(Vector3.up, angle);
        }
    }
}
