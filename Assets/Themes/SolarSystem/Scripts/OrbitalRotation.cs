using UnityEngine;

namespace UnityBase.SolarSystem
{
    public class OrbitalRotation : MonoBehaviour
    {
        [SerializeField]
        private GameObject pivotOrbitalRotationPoint;
        [SerializeField]
        private GameObject GUISlider;

        [SerializeField]
        private float rotationSpeed = 0.0f;
        private float multiplier = 1.0f;

        private Vector3 offset;
        private float rotationY = 0.0f;

        private Vector3[] coords;

        void Start()
        {
            coords = new Vector3[1];
            offset = pivotOrbitalRotationPoint.transform.position - transform.position;
            coords[0] = gameObject.transform.position;
        }

        void Update()
        {
            multiplier = GUISlider.GetComponent<SpeedUpRotation>().RotationSpeedMultiplier;
            rotationY += (1.0f / rotationSpeed) * multiplier;
            Quaternion rotation = Quaternion.Euler(0, rotationY, 0);
            transform.position = pivotOrbitalRotationPoint.transform.position - ((rotation) * offset);
        }
    }
}
