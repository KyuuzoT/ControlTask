﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBase.ChooseColor.Game.Scripts
{
    public class SpriteBehaviour : MonoBehaviour
    {
        [SerializeField] SpriteRenderer[] renderers;

        private void Awake()
        {
            renderers = GetComponents<SpriteRenderer>();
        }

        internal void SetColor(Color color)
        {
            foreach (var item in renderers)
            {
                item.color = color;
            }
        }
    }
}
