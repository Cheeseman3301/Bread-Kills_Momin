using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
       
       if (scoreText == null)
        {
            scoreText = GetComponentInChildren<TextMeshProUGUI>();
            if (scoreText == null)
            {
                Debug.LogError("TextMeshProUGUI component not found!");
                return;
            }
        }

        int loadedScore = PlayerPrefs.GetInt("Score", 0); // Default value is 0 if not found
        scoreText.text = "Score: " + loadedScore;
    }


}
