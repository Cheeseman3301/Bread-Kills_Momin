using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
    public MoveGun moveGun; // Reference to the MoveGun scripts
    public CyborgManager cyborgmanager;
    private bool isWaiting = false;

    void Update()
    {
        if (!isWaiting && moveGun.GetNoofBullets() == 0 || cyborgmanager.GetNoOfCyborgs() < 1)
        {
            isWaiting = true;
            StartCoroutine(LoadNextSceneAfterDelay());
        }
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(5f);
         if (cyborgmanager.GetNoOfCyborgs() > 0)
          {
            Debug.Log("levelfailed");
           SceneManager.LoadScene("RetryLevel");  
          }
        else
          {
            Debug.Log("levelwon");
           SceneManager.LoadScene("ScoreDisplay"); 
          }
        
    }
}