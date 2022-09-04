using UnityEngine;
using UnityEngine.Events;

public class GameplayManager : MonoBehaviour
{
    #region Fields
    LevelGeneratorEvent levelGeneratorEvent = new LevelGeneratorEvent();
    ResetBallEvent resetBallEvent = new ResetBallEvent();
    
    bool endGame = false;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddLevelGeneratorInvoker(this);
        EventManager.AddResetBallInvoker(this);
    }
    #endregion

    #region Unity methods
    // Update is called once per frame
    void Update()
    {
        // pause game on escape key if game isn't currently paused
		if (Input.GetKeyDown(KeyCode.Escape) &&
			Time.timeScale != 0)
		{
            AudioManager.Play(AudioClipName.MenuButtonClick);
			MenuManager.GoToMenu(MenuName.Pause);
		}
        
        if ((GameObject.FindGameObjectsWithTag("Ball").Length == 0)
            && !endGame)
		{
			EndGame();
		}

        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
		{
            Debug.Log("0 Blocks");
            RemoveBall();
            resetBallEvent.Invoke();
			levelGeneratorEvent.Invoke();

            EventManager.RemoveLevelGeneratorInvoker(this);
            EventManager.RemoveResetBallInvoker(this);
		}
    }
    #endregion

    #region Private methods
	// Ends the game
	void EndGame()
	{
        endGame = !endGame;

		// instantiate prefab and set score
		GameObject gameOverMessage = Instantiate(Resources.Load("MenuPrefabs/GameOverMessage")) as GameObject;
		GameOverMessage gameOverMessageScript = gameOverMessage.GetComponent<GameOverMessage>();
		GameObject hud = GameObject.FindGameObjectWithTag("HUD");
		HUD hudScript = hud.GetComponent<HUD>();
		gameOverMessageScript.SetScore(hudScript.Score);
        hud.SetActive(false);
	}

    void RemoveBall()
    {
        while(GameObject.FindGameObjectsWithTag("Ball").Length > 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
        }
    }
    #endregion

    #region Event methods
    public void AddLevelGeneratorListener(UnityAction listener)
    {
        levelGeneratorEvent.AddListener(listener);
    }

    public void AddResetBallListener(UnityAction listener)
    {
        resetBallEvent.AddListener(listener);
    }
    #endregion
}