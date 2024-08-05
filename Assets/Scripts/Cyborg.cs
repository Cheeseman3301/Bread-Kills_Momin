using UnityEngine;
using System.Collections;

public class Cyborg : MonoBehaviour
{
    public int scoreValue = 200;
    [SerializeField] public int noOfCyborgs;
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

      noOfCyborgs--;
      Debug.Log("Here:" + noOfCyborgs);
       
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
        Debug.Log("NoofCyborgs: " + noOfCyborgs);
    
    }
    public int GetNoOfCyborgs()
    {
        return noOfCyborgs;
    }
}


