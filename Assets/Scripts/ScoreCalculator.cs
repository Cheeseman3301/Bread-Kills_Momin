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

    public void CyborgKilled(Cyborg cyborg)
    {
        // ...
    }
}
