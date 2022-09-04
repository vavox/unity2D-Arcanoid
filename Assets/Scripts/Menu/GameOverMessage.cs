using UnityEngine;
using TMPro;

public class GameOverMessage : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI messageText;

    void Start()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    // Sets score
    public void SetScore(int score)
    {
        messageText.text = "Game Over!\n\nYour score: " +
            score.ToString();
    }

    // Moves to main menu when quit button clicked
    public void HandleQuitButtonClicked()
    {
        // unpause game, destroy menu, and go to main menu
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
