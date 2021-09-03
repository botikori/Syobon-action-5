using System.Collections.Generic;
using UnityEngine;

namespace MenuManagement
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Menu[] menuPrefabs;
        [SerializeField] private Transform menuParent;
        
        private Stack<Menu> _menuStack = new Stack<Menu>();
        
        private static MenuManager _instance;

        public static MenuManager Instance { get => _instance; }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeMenus();
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        private void InitializeMenus()
        {
            if (menuParent == null)
            {
                GameObject menuParentGameObject = new GameObject("Menus");
                menuParent = menuParentGameObject.transform;
            }

            DontDestroyOnLoad(menuParent.gameObject);

            foreach (var menuPrefab in menuPrefabs)
            {
                if (menuPrefab != null)
                {
                    Menu menuInstance = Instantiate(menuPrefab, menuParent);

                    if (menuInstance != MainMenu.Instance)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }
        
        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.LogWarning("Null menu");
                return;
            }

            if (_menuStack.Count > 0)
            {
                foreach (var menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }
            
            menuInstance.gameObject.SetActive(true);
            _menuStack.Push(menuInstance);
        }

        public void CloseMenu()
        {
            if (_menuStack.Count == 0)
            {
                Debug.LogWarning("No menus in stack");
                return;
            }

            Menu topMenu = _menuStack.Pop();
            topMenu.gameObject.SetActive(false);

            if (_menuStack.Count > 0)
            {
                Menu nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}