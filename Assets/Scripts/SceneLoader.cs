using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour   
{
    public MoveGun moveGun; // Reference to the MoveGun script

    private bool isWaiting = false;

    void Update()
    {
        if (!isWaiting && moveGun.GetNoofBullets() == 0)
        {
            isWaiting = true;
            StartCoroutine(LoadNextSceneAfterDelay());
        }
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("ScoreDisplay");
    }
}
