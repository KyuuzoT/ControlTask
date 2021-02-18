using System;
using System.Collections;
using System.Collections.Generic;
using UnityBase.CommonResources.CommonButtons;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityBase.MenuScene.Menu
{
    public class ButtonsBehaviour : MonoBehaviour
    {
        internal List<Button> buttonsOnScene;
        private MenuManager manager;
        private Transform activeLayout;

        private ButtonClickedHandler btnHandler;

        private void Awake()
        {
            buttonsOnScene = new List<Button>();
            manager = GetComponent<MenuManager>();

            btnHandler = new ButtonClickedHandler();
            btnHandler.Manager = manager;
        }

        // Update is called once per frame
        void Update()
        {
            activeLayout = GetCurrentActiveLayout();
            SetButtonsBehaviour(GetButtonsOnLayout(activeLayout));
        }

        private Transform GetCurrentActiveLayout()
        {
            Transform active = manager.currentLayout.transform;
            btnHandler.ActiveLayout = active;
            return active;
        }

        private List<Button> GetButtonsOnLayout(Transform layout)
        {
            List<Button> btnList = new List<Button>();
            btnList.AddRange(layout.GetComponentsInChildren<Button>());

            return btnList;
        }

        private void SetButtonsBehaviour(List<Button> buttons)
        {
            List<Button> btnList = new List<Button>(buttons);
            foreach (var btn in btnList)
            {
                btn.onClick.RemoveAllListeners();

                btn.onClick
                    .AddListener(
                                    delegate
                                    {
                                        btnHandler.ButtonClicked(btn.name);
                                    });
            }
        }
    }
}
