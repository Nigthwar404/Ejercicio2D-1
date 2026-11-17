using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionTime;
    public float elapsedTime;
    public Vector3 explosionOffset;
    private Collider col;
    public GameObject explosion;
    public float explosionDuration;
    private MeshRenderer mR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
        mR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime+= Time.deltaTime;
        if (elapsedTime >= explosionTime && col.enabled==false)
        {
            col.enabled=true;
            Instantiate(explosion,transform.position + explosionOffset,explosion.transform.rotation);
            mR.enabled = false;
        }
        if (elapsedTime >= explosionTime + explosionDuration)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameManager.instance.ResetScene();
        }
        else if (other.CompareTag("Box")||  other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        
    }
}
