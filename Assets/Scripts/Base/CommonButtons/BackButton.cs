using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityBase.CommonResources.CommonButtons
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField] Button back;
        private ButtonClickedHandler btnHandler;

        // Start is called before the first frame update
        void Start()
        {
            btnHandler = new ButtonClickedHandler();
        }

        // Update is called once per frame
        void Update()
        {
            SetButtonsBehaviour(back);

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(ScenesInBuild.Main.ToString());
            }
        }

        private void SetButtonsBehaviour(params Button[] buttons)
        {
            foreach (var btn in buttons)
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
