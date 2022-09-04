using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName menu)
    {
        switch(menu)
        {
            case MenuName.Play: // go to Gameplay scene
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuName.Main: // go to Main Menu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Help: // go to Help Menu scene 
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Pause: // instantiate pause prefab object
                Object.Instantiate(Resources.Load("MenuPrefabs/PauseMenu"));
                break;
            default:
                break;
        }
    }
}