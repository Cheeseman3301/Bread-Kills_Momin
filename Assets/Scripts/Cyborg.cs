using UnityEngine;
using System.Collections;

public class Cyborg : MonoBehaviour
{
    public int scoreValue = 200;
    private bool isHit = false;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnDestroy()
    {
        ScoreManager.instance.AddScore(scoreValue);
    }
   
    public void OnHit() // Function called when the cyborg is hit by a bullet
    {
        isHit = true;
        animator.SetBool("isHit", isHit);
       StartCoroutine(ResetHit());
    }
    IEnumerator ResetHit()
   {
    yield return new WaitForSeconds(2.0f);
    isHit = false;
    animator.SetBool("isHit", isHit);
    }
    void Update()
    {
        bool animatorIsHit = animator.GetBool("isHit");
        Debug.Log("Animator isHit: " + animatorIsHit);
    
    // if (isHit)
    //   {
    //     // Trigger the "Hit" animation using a trigger parameter
    //     isHit = false; // Reset the flag after triggering the animation
    //   }
    }
}


