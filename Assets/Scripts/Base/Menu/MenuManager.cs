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
        private List<Button> buttonsOnActiveLayout;

        internal bool isCurrentLayoutOn = true;
        internal bool isNextLayoutOn = false;

        private void Awake()
        {
            GetButtonsOnCurrentLayout();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(!isCurrentLayoutOn && isNextLayoutOn)
            {
                GetButtonsOnCurrentLayout();
                isCurrentLayoutOn = true;
                isNextLayoutOn = false;
            }
        }

        private void GetButtonsOnCurrentLayout()
        {
            buttonsOnActiveLayout = new List<Button>();
            foreach (var item in menuLayouts.Where(x => x.activeSelf.Equals(true)))
            {
                buttonsOnActiveLayout.AddRange(item.GetComponentsInChildren<Button>());
            }

            foreach (var item in buttonsOnActiveLayout)
            {
                Debug.Log(item);
            }
        }
    }
}
