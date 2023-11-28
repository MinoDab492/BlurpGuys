using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public Menu[] menus;

    void Awake()
    {
        instance = this;
    }

    public void OpenMenu(string menuname)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuname)
            {
               menus[i].OpenMenu();

            }else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.OpenMenu();
    }

    public void CloseMenu(Menu menu)
    {
        menu.CloseMenu();
    }

}
