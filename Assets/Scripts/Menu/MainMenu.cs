using UnityEngine;

public class MainMenu : MonoBehaviour
{
	#region Public methods
	// Goes to the difficulty menu
	public void GoToGameplay()
    {
		AudioManager.Play(AudioClipName.MenuButtonClick);
		MenuManager.GoToMenu(MenuName.Play);
    }

	// Shows the help menu
	public void ShowHelp()
	{
		AudioManager.Play(AudioClipName.MenuButtonClick);
		MenuManager.GoToMenu(MenuName.Help);
	}

	// Exits the game
	public void ExitGame()
	{
		AudioManager.Play(AudioClipName.MenuButtonClick);
		Application.Quit();
	}
	#endregion
}
