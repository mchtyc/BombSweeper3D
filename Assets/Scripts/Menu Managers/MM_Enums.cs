using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuPage {WorldPage, LevelPage}

public class MM_Enums : MonoBehaviour
{
    public static MenuPage menuPage;

    public static void SetMenuPage(MenuPage page)
    {
        menuPage = page;
    }

    public static MenuPage GetMenuPage()
    {
        return menuPage;
    }
}
