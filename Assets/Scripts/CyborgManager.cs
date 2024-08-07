using UnityEngine;

public class CyborgManager : MonoBehaviour
{
    public static CyborgManager instance; // Singleton instance

    //[SerializeField] 
    public int totalCyborgs; // Total number of cyborgs in the scene

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction on scene load
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize totalCyborgs based on the number of cyborgs in the scene
        totalCyborgs = GameObject.FindGameObjectsWithTag("Enemy").Length;
         Debug.Log("NoofCyborgs: " + totalCyborgs);
    }

    public void DecrementCyborgCount()
    {
        totalCyborgs--;
         Debug.Log("NoofCyborgs: " + totalCyborgs);

        // Add logic for when the last cyborg is destroyed (e.g., load next scene)
        if (totalCyborgs <= 0)
        {
            // Load next scene or perform other actions
            Debug.Log("All cyborgs destroyed!");
        }
    }
     public int GetNoOfCyborgs()
    {
        return totalCyborgs;
    }

  
}

