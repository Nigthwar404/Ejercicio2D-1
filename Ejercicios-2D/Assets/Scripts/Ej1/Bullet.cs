using Unity.ProjectAuditor.Editor.Core;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int daño;
    public Vector2 dir;
    public Vector2 bulletdir;
    public bool EnemyBullet;
    public bool playerBullet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (EnemyBullet == false)
        {
            if (transform.position.x >= 0)
            {
                transform.Translate(-bulletdir * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(bulletdir * speed * Time.deltaTime);
            }
        }
        else
        {
                transform.Translate(-bulletdir * speed * Time.deltaTime);
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && EnemyBullet ==true)
        {
            GameManager.instance.RemoveLife();
            Destroy(gameObject);            
            
        }
        if (collision.CompareTag("Turret")&& EnemyBullet == false)
        {
            GameManager.instance.AddPoints();
            Destroy(gameObject);
        }
        if (collision.CompareTag("EndWall"))
        {
            Destroy(gameObject);
        }
        if (playerBullet == true && collision.CompareTag("EnemyBullet") )
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
