using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;
    public TextMeshProUGUI scoreText;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int GetScore()
    {
        return score;
    }

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }
    private void Update()
    {
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score + " Bullets: " + MoveGun.instance.NoOfBullets;
    }
    void OnDestroy()
    {
        // Save score to PlayerPrefs when the scene is about to be destroyed
        PlayerPrefs.SetInt("Score", score);
    }
    
}




