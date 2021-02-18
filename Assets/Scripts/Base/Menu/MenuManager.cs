using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UnityBase.MenuScene.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> menuLayouts;
        internal List<Button> buttonsOnLayout;
        internal GameObject currentLayout;
        internal GameObject nextLayout;
        internal GameObject prevLayout;

        internal bool isCurrentLayoutOn = true;
        internal bool isNextLayoutOn = false;

        private int layoutsIndex = 0;

        private void Awake()
        {
            currentLayout = menuLayouts.Where(x => x.activeSelf.Equals(true)).First();
            nextLayout = menuLayouts.Where(x => menuLayouts.IndexOf(x) != menuLayouts.IndexOf(currentLayout)).First();
        }

        private void GetNextAndCurrentLayouts()
        {
            foreach (var item in menuLayouts)
            {
                if (item.activeSelf)
                {
                    currentLayout = item;
                    layoutsIndex = menuLayouts.FindIndex(x => x.name.Equals(item));

                    if (layoutsIndex >= menuLayouts.Count)
                    {
                        layoutsIndex = 0;
                    }
                    else
                    {
                        layoutsIndex++;
                    }
                    nextLayout = menuLayouts[layoutsIndex];
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!isCurrentLayoutOn && isNextLayoutOn)
            {
                isCurrentLayoutOn = true;
                isNextLayoutOn = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!prevLayout.Equals(null))
                {
                    EscapeButtonHandler();
                }
            }
        }

        private void EscapeButtonHandler()
        {
            currentLayout.SetActive(false);
            currentLayout = prevLayout;
            currentLayout.SetActive(true);
            nextLayout = menuLayouts.Where(x => menuLayouts.IndexOf(x) != menuLayouts.IndexOf(currentLayout)).First();
        }

        internal List<Button> GetButtons()
        {
            List<Button> buttons = new List<Button>();
            foreach (var item in menuLayouts)
            {
                buttons.AddRange(item.GetComponentsInChildren<Button>());
            }

            return buttons;
        }

        internal void ChangeActiveLayout(Transform current)
        {
            if (currentLayout.name.Equals(current.name))
            {
                currentLayout.SetActive(false);
                prevLayout = currentLayout;
                nextLayout.SetActive(true);
                GetNextAndCurrentLayouts();
            }
        }
    }
}
