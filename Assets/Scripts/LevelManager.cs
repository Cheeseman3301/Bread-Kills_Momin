using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager {
    public static int currentLevelIndex = 1;
    public static int totalLevelCount = 5; 

    public static void LoadNextLevel() {
        currentLevelIndex++;

        if (currentLevelIndex <= totalLevelCount) {
            SceneManager.LoadScene("Level" + currentLevelIndex);
        } else {
            SceneManager.LoadScene("ScoreDisplay");
        }
    }
}
