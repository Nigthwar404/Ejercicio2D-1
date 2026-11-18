using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bala;
    public float timeToShoot;
    public float elapsedTime;
    public Transform shootposF;
    public Transform shootposB;
    public Bullet bS;
    public Vector2 direction;


    void Start()
    {
        timeToShoot = Random.Range(5,15);
        
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timeToShoot)
        {
            elapsedTime = 0;
            Shoot();
        }

    }
    private void Shoot()
    {
        if (transform.position.x>=0)
        {
            bS.EnemyBullet =true;
            bS.bulletdir= direction;
            Instantiate(bala,gameObject.transform.position,bala.transform.rotation);
        }
        else
        {
            bS.EnemyBullet =true;
            bS.bulletdir = direction;
            Instantiate(bala, gameObject.transform.localPosition, bala.transform.rotation);
        }
            
    }
}
