using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInst;
    public float bulletSpeed = 4.0f;
    public Vector2 direction;

    private float lastTapTime;
    private const float doubleTapTime = 0.3f; // Adjust this value as needed
    public int NoOfBullets = 5;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("touching screen");
                HandleGunRotation(touch);

            }

            if (touch.phase == TouchPhase.Ended)
            {
                float currentTime = Time.time;
                if (currentTime - lastTapTime <= doubleTapTime)
                {
                    Debug.Log("double tap detected");
                    if (NoOfBullets>0)
                    {
                       NoOfBullets--;
                       fireBullet();
                    }
                    
                }
                lastTapTime = currentTime;
            }
        }
    }

    private void HandleGunRotation(Touch touch)
    {
        // Get the touch position in world coordinates
        Vector2 touchPosition = touch.position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        // Calculate the direction from the gun to the touch position
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        // Rotate the gun to face the touch position
        gun.transform.right = direction;
    }

  void fireBullet()
    {
        
        bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
        bulletInst.GetComponent<Rigidbody2D>().velocity = gun.transform.right * bulletSpeed;
        
    }
    
    
}