using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bomb;
    public float spawnTime;
    public float elapsedTime;
    public GameObject currentBomb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentBomb == null)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= spawnTime)
            {
                currentBomb = Instantiate(bomb, transform.position, bomb.transform.rotation);
                elapsedTime =0f;
            }
        }
    }
}
