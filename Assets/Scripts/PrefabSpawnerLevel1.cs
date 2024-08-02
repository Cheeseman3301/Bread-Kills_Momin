using UnityEngine;

public class PrefabSpawnerLevel1 : MonoBehaviour
{
    public GameObject[] ledges = new GameObject[2]; // Array to hold 2 prefabs
    public GameObject[] cyborgs = new GameObject[2];
    public GameObject backgroundPrefab;
    public GameObject wall;
    public GameObject bread;

    public Vector3[] ledgesPos = new Vector3[2]; // Array to hold positions for 2 prefabs
    public Vector3[] cyborgPos = new Vector3[2];
    Vector3 backgroundPos = new Vector3(0.0145f, -0.0003f, 0f);

    Vector3 ledgesPos0 = new Vector3(1.31f, -1.59f, 0);
    Vector3 ledgesPos1 = new Vector3(-1.3f, 0.74f, 0);
    Vector3 cyborgPos0 = new Vector3(0.75f, -0.68f, 0);
    Vector3 cyborgPos1 = new Vector3(-1.79f, 1.66f, 0);
    Vector3 wallpos = new Vector3(0.1234f,0.6120f,0f);
    Vector3 breadpos = new Vector3(-1.48f,-3.58f,0f);

    void Start()
    {
        Instantiate(backgroundPrefab, backgroundPos, Quaternion.identity);
        Instantiate(wall, wallpos, Quaternion.identity);

       // for (int i = 0; i < ledges.Length; i++)
       // {
            GameObject breadinstance = Instantiate(bread, breadpos,Quaternion.identity);
            GameObject ledgeInstance = Instantiate(ledges[0], ledgesPos0, Quaternion.identity);
            GameObject ledgeInstance2 = Instantiate(ledges[1], ledgesPos1, Quaternion.identity);
            GameObject cyborgInstance = Instantiate(cyborgs[0], cyborgPos0, Quaternion.identity);
            GameObject cyborgInstance2 = Instantiate(cyborgs[0], cyborgPos1, Quaternion.identity);
       // }
    }
}
