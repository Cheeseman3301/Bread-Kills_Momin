using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void LoadPrevLevel()
    {
        Debug.Log("Retry button pressed!");
        LevelManager.LoadPreviousLevel();
    }
}

