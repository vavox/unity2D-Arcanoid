// HUD component
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject scoreTextGameObject;

    const string ScorePrefix = "SCORE: ";

    static TextMeshProUGUI scoreText;

    static int score = 0;
    #endregion

    #region Properties
    // Get Score
    public int Score
    {
        get { return score; }
    }
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = scoreTextGameObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = ScorePrefix + score.ToString();
        EventManager.AddAddPointsListener(AddPoints);
    }
    #endregion

    #region Public methods
    // Adds the given points to the score
    public static void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }
    #endregion
}
