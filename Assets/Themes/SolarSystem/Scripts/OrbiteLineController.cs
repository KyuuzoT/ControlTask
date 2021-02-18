using UnityEngine;

namespace UnityBase.SolarSystem
{
    public class OrbiteLineController : MonoBehaviour
    {
        private LineRenderer line;
        private Transform[] points;
        [SerializeField]
        [Range(0.01f, 1.0f)]
        private float lineMultiplier = 0.1f;

        private void Awake()
        {
            line = gameObject.AddComponent<LineRenderer>();
            line.widthMultiplier = lineMultiplier;
        }

        internal void SetUpLine(Transform[] points)
        {
            line.positionCount = points.Length;
            this.points = points;
        }

        private void Update()
        {
            for (int i = 0; i < points.Length; i++)
            {
                line.SetPosition(i, points[i].position);
            }
        }
    }
}