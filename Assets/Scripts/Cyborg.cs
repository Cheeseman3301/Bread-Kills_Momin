using UnityEngine;
using System.Collections;

public class Cyborg : MonoBehaviour
{
    public int scoreValue = 200;
    private bool isHit = false;
    Animator animator;
    private Collider2D cyborgCollider;
    int hits = 0;
    public CyborgManager cyborgManager;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        cyborgCollider = GetComponent<Collider2D>();
        cyborgManager = FindObjectOfType<CyborgManager>();
    }
    private void OnDestroy()
    {
       // ScoreManager.instance.AddScore(scoreValue);
    }
   
    public void OnHit() // Function called when the cyborg is hit by a bullet
    {
      hits++;
      isHit = true;
      animator.SetBool("isHit", isHit);
      StartCoroutine(ResetHit());
      if (hits==1)
      {
        ScoreManager.instance.AddScore(scoreValue);
        cyborgManager.DecrementCyborgCount();
      }

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
        
    
    }
   
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (!HitOnce && collision.gameObject.CompareTag("Bullet"))
    //     {
    //         HitOnce = true;
    //         //cyborgCollider.isTrigger = true; // Enable trigger
    //         // Handle hit logic here
    //     }
    //     else 
    //     {
    //          Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
    //     }
   // }
    void DestroyObject()
   {
    GetComponent<Renderer>().enabled = false;
   }

}