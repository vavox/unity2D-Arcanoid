using UnityEngine;

// Initializes the game
public class GameInitializer : MonoBehaviour 
{
    // Awake is called before Start
	void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
    }
}
