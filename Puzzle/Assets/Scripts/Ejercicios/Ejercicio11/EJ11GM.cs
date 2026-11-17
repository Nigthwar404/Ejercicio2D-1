using UnityEngine;

public class EJ11GM : MonoBehaviour
{
public static EJ11GM instance;
public bool KeyDestroyed;
public bool spawned;
public GameObject cubeToSpawn;
public GameObject player;
public float time;
public float move;
public int dist;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        ;
        if (player == null)
        {
            KeyDestroyed = true;            
        }
        if (KeyDestroyed == true && spawned == false)
        {
            spawned = true;
            Instantiate(cubeToSpawn, transform.position, transform.rotation);
        }

    }
}
