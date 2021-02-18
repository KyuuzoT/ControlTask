using System;
using System.Collections;
using System.Collections.Generic;
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

        private void Awake()
        {
            buttonsOnScene = new List<Button>();
            manager = GetComponent<MenuManager>();
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
                                        ButtonClicked(btn.name);
                                    });
            }
        }

        private void ButtonClicked(string name)
        {
            switch (name)
            {
                case "btnChoose":
                    manager.ChangeActiveLayout(activeLayout);
                    break;
                case "btnFirst":
                    SceneManager.LoadScene(CommonResources.ScenesInBuild.Game.ToString());
                    break;
                case "btnSecond":
                    SceneManager.LoadScene(CommonResources.ScenesInBuild.Main.ToString());
                    break;
                case "btnThird":
                    break;
                default:
                    break;
            }
        }
    }
}
