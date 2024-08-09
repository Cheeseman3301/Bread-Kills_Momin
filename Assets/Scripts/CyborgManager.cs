using UnityEngine;

public class CyborgManager : MonoBehaviour
{
    public static CyborgManager instance; // Singleton instance

    public int totalCyborgs; // Total number of cyborgs in the scene
    private void Start()
    {
        // Initialize totalCyborgs based on the number of cyborgs in the scene
        totalCyborgs = GameObject.FindGameObjectsWithTag("Enemy").Length;
          Debug.Log("NoofCyborgs: " + totalCyborgs);
    }

     public void ResetCyborgCount()
    {
        totalCyborgs =  GameObject.FindGameObjectsWithTag("Enemy").Length;

    }

    public void DecrementCyborgCount()
    {
        totalCyborgs--;
         Debug.Log("NoofCyborgs: " + totalCyborgs);
        if (totalCyborgs <= 0)
        {
            Debug.Log("All cyborgs destroyed!");

        }
    }
     public int GetNoOfCyborgs()
    {
        return totalCyborgs;
    }

  
}

