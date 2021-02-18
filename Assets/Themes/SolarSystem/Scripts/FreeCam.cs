using UnityEngine;

namespace UnityBase.SolarSystem
{
    public class FreeCam : MonoBehaviour
    {
        [SerializeField]
        private float sensivity = 3.0f;
        [SerializeField]
        private float flySpeed = 5.0f;
        private Vector3 transfer;

        private float minX = -360.0f;
        private float maxX = 360.0f;
        private float minY = -60.0f;
        private float maxY = 60.0f;

        private float rotationX;
        private float rotationY;

        private Quaternion originalRotation;

        private void Awake()
        {
            GetComponent<Camera>().orthographic = false;
        }

        void Start()
        {
            originalRotation = transform.rotation;
        }

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                rotationX += Input.GetAxis("Mouse X") * sensivity;
                rotationX = ClampAngle(rotationX, minX, maxX);
                var QuaternionX = Quaternion.AngleAxis(rotationX, Vector3.up);

                rotationY += Input.GetAxis("Mouse Y") * sensivity;
                rotationY = ClampAngle(rotationY, minY, maxY);
                var QuaternionY = Quaternion.AngleAxis(rotationY, Vector3.left);

                transform.rotation = originalRotation * QuaternionX * QuaternionY;

                transfer = transform.forward * Input.GetAxis("Vertical");
                transfer += transform.right * Input.GetAxis("Horizontal");
                transform.position += transfer * flySpeed * Time.deltaTime;
            }
        }

        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < min)
            {
                angle -= min;
            }
            else if (angle > max)
            {
                angle -= max;
            }

            return Mathf.Clamp(angle, min, max);
        }
    }
}
