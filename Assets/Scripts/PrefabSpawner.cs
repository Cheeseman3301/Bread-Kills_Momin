using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] ledges = new GameObject[4]; // Array to hold 3 prefabs
    public GameObject [] cyborgs = new GameObject[4];
    public GameObject[] wallvertical= new GameObject[2];
    public GameObject[] wallhorizontal= new GameObject[2];
    public GameObject backgroundPrefab;
    public GameObject gun;
    public GameObject bread;
    public GameObject arm;
    

    public Vector3[] ledgespos = new Vector3[4];   // Array to hold positions for 3 prefabs
    public Vector3[] cyborgpos = new Vector3[4]; 
    public Vector3[] wallverticalpos = new Vector3[2];  
    public Vector3[] wallhorizontalpos = new Vector3[2];
    Vector3 backgroundPos = new Vector3(0.0177f, -0.02f, 0f); // Adjust position as needed
    Vector3 gunPos = new Vector3(-0.52f, -3.74f, -0f); // Adjust values for your scene
    Vector3 breadPos = new Vector3(-1.5283f, -3.9115f, 0f); // Adjust values for your scene
    Vector3 armPos = new Vector3(-1.525f,-3.841f,0f);
    
    void Start()
    {

        ledgespos[0] = new Vector3(-1.59f, 1.91f, 0);
        ledgespos[1] = new Vector3(1.71f, 0.57f, 0);
        ledgespos[2] = new Vector3(-1.36f, -1.15f, 0);
        ledgespos[3] = new Vector3(1.64f, -2.16f, 0);

        cyborgpos[0] = new Vector3(1.5866f, -1.3877f, 0);
        cyborgpos[1] = new Vector3(-2.3f, -0.35f, 0);
        cyborgpos[2] = new Vector3( 1.54f, 1.36f, 0);
        cyborgpos[3] = new Vector3(-2.23768f, 2.686826f, 0);


       wallverticalpos[0] = new Vector3(3.240632f, 0.09348774f, 0);
       wallverticalpos[1] = new Vector3(-3.32f, 0f, 0);
       wallhorizontalpos[0] = new Vector3(0.08f, 6.08f, 0);
       wallhorizontalpos[1] = new Vector3(-0.03f, -6.14f, 0);

        Instantiate(backgroundPrefab, backgroundPos, Quaternion.identity); 
        Instantiate(gun, gunPos, Quaternion.identity); 
        Instantiate(bread, breadPos, Quaternion.identity); 
        Instantiate(arm, armPos, Quaternion.identity);
        
        for (int i=0;i<2;i++)
        {
            GameObject prefabInstance = Instantiate(wallvertical[i], wallverticalpos[i], Quaternion.identity);
            GameObject prefabInstance2 = Instantiate(wallhorizontal[i], wallhorizontalpos[i], Quaternion.identity);
        }
        
        for (int i = 0; i < 4; i++)
        {
            if (i !=3)
             {GameObject prefabInstance = Instantiate(ledges[i], ledgespos[i], Quaternion.identity);}

            GameObject prefabInstance2 = Instantiate(cyborgs[i], cyborgpos[i], Quaternion.identity);
        }
        Destroy(ledges[0]);
    }
}