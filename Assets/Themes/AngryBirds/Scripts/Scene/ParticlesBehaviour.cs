using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBase.AngryBirds.Game.Scripts.Scene
{
    public class ParticlesBehaviour : MonoBehaviour
    {
        void Update()
        {
            if (gameObject.GetComponent<ParticleSystem>().isStopped)
            {
                Destroy(gameObject);
            }
        }
    }
}