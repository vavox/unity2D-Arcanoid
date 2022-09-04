using UnityEngine;

/// The pause menu
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }

    // Resumes the paused game
    public void ResumeGame()
    {
        // unpause game and destroy menu
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    // Quits the paused game
    public void QuitGame()
    {
        // unpause game, destroy menu, and go to main menu
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
