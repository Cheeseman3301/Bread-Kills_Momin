using UnityEngine;

public class Cyborg : MonoBehaviour
{
    public int scoreValue = 200;

    private void OnDestroy()
    {
        ScoreManager.instance.AddScore(scoreValue);
    }
}


