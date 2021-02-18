using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityBase.CommonResources.CommonButtons
{
    public class ButtonClickedHandler
    {
        private Transform activeLayout;

        internal Transform ActiveLayout
        {
            get => activeLayout;
            set
            {
                activeLayout = value;
            }
        }

        private MenuScene.Menu.MenuManager manager;

        internal MenuScene.Menu.MenuManager Manager
        {
            get => manager;
            set
            {
                manager = value;
            }
        }

        internal void ButtonClicked(string name)
        {
            switch (name)
            {
                case "btnChoose":
                    manager.ChangeActiveLayout(activeLayout);
                    break;
                case "btnFirst":
                    SceneManager.LoadScene(ScenesInBuild.SolarSystemScene.ToString());
                    break;
                case "btnSecond":
                    SceneManager.LoadScene(ScenesInBuild.Main.ToString());
                    break;
                case "btnThird":
                    break;
                case "btnBack":
                    SceneManager.LoadScene(ScenesInBuild.Main.ToString());
                    break;
                default:
                    break;
            }
        }
    }
}
