using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager {
    public static int currentLevelIndex = 1;
    public static int totalLevelCount = 5; 

    public static void LoadNextLevel() {
        currentLevelIndex++;
        if (currentLevelIndex > totalLevelCount+1)
        {
            SceneManager.LoadScene("LastScene");
        }
        else if (currentLevelIndex <= totalLevelCount) {
            SceneManager.LoadScene("Level" + currentLevelIndex);
        } else {
            SceneManager.LoadScene("ScoreDisplay");
        }
    }
     public static void LoadPreviousLevel() {
        //currentLevelIndex--;

        if (currentLevelIndex >= 0) {
            SceneManager.LoadScene("Level" + currentLevelIndex);
        } else {
            SceneManager.LoadScene("LastScene");
        }
    }
}
