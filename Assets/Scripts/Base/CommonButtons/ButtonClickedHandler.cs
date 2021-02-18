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
                case "btnExit":
#if !UNITY_EDITOR
                    Application.Quit();
#else
                    UnityEditor.EditorApplication.ExitPlaymode();
#endif
                    break;
                case "btnFirst":
                    SceneManager.LoadScene(ScenesInBuild.SolarSystemScene.ToString());
                    break;
                case "btnSecond":
                    SceneManager.LoadScene(ScenesInBuild.PlatformerSceneMain.ToString());
                    break;
                case "btnThird":
                    SceneManager.LoadScene(ScenesInBuild.Colors.ToString());
                    break;
                case "btnFourth":
                    break;
                case "btnBack":
                    SceneManager.LoadScene(ScenesInBuild.AngryBirds.ToString());
                    break;
                default:
                    break;
            }
        }
    }
}
