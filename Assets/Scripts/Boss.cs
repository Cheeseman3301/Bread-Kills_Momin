using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform respawnPoint; // Assign the transform object in the inspector
    public Transform respawnPoint2; // Assign the transform object in the inspector
    public int scoreValue = 200;
    private bool isHit = false;
    Animator animator;
    private Collider2D bossCollider;
    int hits = 0;
    public CyborgManager cyborgManager;
  
    Animator newBossAnimator;
    public void Respawn()
    {
    
    GetComponent<Renderer>().enabled = false;
    GetComponent<Collider2D>().enabled = false;
    if (hits == 1)
    {
      transform.position = respawnPoint.position;
      transform.rotation = respawnPoint.rotation;
    }
    else if (hits == 2)
    {
      transform.position = respawnPoint2.position;
      transform.rotation = respawnPoint2.rotation;
    }
    // Enable components
    GetComponent<Renderer>().enabled = true;
    GetComponent<Collider2D>().enabled = true;
    }
    
    void Start()
    {
        animator = GetComponent<Animator>();
        bossCollider = GetComponent<Collider2D>();
        cyborgManager = FindObjectOfType<CyborgManager>();
    }
    public void OnHit() 
    {
      hits++;
      ScoreManager.instance.AddScore(scoreValue);
      
        if (hits == 1 || hits == 2)
      {
        Respawn();
        
      }
      if (hits == 3)
      {
        isHit = true;
        animator.SetBool("isHit", isHit);
        StartCoroutine(ResetHit());
        cyborgManager.DecrementCyborgCount();
      }
    

    }
    IEnumerator ResetHit()
   {
    yield return new WaitForSeconds(2.0f);
    isHit = false;
    animator.SetBool("isHit", isHit);
    }
   
    void DestroyObject()
   {
    GetComponent<Renderer>().enabled = false;
   }

}
