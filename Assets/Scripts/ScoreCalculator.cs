
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;
    public TextMeshProUGUI scoreText;

    public MoveGun moveGun; // Reference to MoveGun script

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
        moveGun = FindObjectOfType<MoveGun>(); // Find MoveGun script in the scene
        UpdateScoreText();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score + " Bullets: " + moveGun.NoOfBullets;
    }

  
    public void CyborgKilled(Cyborg cyborg)
   {

     //if (bullet.kills >= 2)
       // {
            // Award double kill bonus
          //  score += 100;
            // Update UI or play sound effect for double kill
       // }
    
   }
    
}
