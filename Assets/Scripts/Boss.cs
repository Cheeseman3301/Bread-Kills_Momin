using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform respawnPoint; // Assign the transform object in the inspector
    public int scoreValue = 200;
    private bool isHit = false;
    Animator animator;
    private Collider2D bossCollider;
    int hits = 0;
    //public GameObject bossPrefab;
    Animator newBossAnimator;
    public void Respawn()
    {
    
    GetComponent<Renderer>().enabled = false;
    GetComponent<Collider2D>().enabled = false;
    
    transform.position = respawnPoint.position;
    transform.rotation = respawnPoint.rotation;

    // Enable components
    GetComponent<Renderer>().enabled = true;
    GetComponent<Collider2D>().enabled = true;
    }
    
    void Start()
    {
        animator = GetComponent<Animator>();
        bossCollider = GetComponent<Collider2D>();
    }
    public void OnHit() // Function called when the cyborg is hit by a bullet
    {
      hits++;
      ScoreManager.instance.AddScore(scoreValue);
      
        if (hits == 1)
      {
        Respawn();
        
      }
      if (hits == 2)
      {
        isHit = true;
        animator.SetBool("isHit", isHit);
        StartCoroutine(ResetHit());
        CyborgManager.instance.DecrementCyborgCount();
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
