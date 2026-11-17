using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    public bool isforward;
    public float lifeTime;
    public bool cannonBall;
    //transform de un objeto en la escena al que sigue el enemigo
    public Transform target;
    public bool dirx;
    public bool dirz;

    public Transform nextTarget;
    public Vector3 nextDir;

    public void Start()
    {
        if (cannonBall == true)
        {
            Destroy(gameObject, lifeTime);
        }

    }
    void Update()
    {
        /*
        if (!isforward)
        {
            transform.Translate(speed * -dir * Time.deltaTime);
        }
        else
        {
            transform.Translate(speed * dir * Time.deltaTime);
        }
        */
        transform.Translate(speed * dir * Time.deltaTime);

        if (cannonBall == false)
        {
            if (dirx == true)
            {
                if (dir.x > 0)
                {//se comprueba si el enemigo ha llegado a la posicion
                    if (transform.position.x >= target.position.x)
                    {
                        SetNewDir();
                    }
                }
                else
                {
                    if (transform.position.x <= target.position.x)
                    {
                        SetNewDir();
                    }
                }
            }
             if (dirz == true)
            {
                if (dir.z > 0)
                {//se comprueba si el enemigo ha llegado a la posicion
                    if (transform.position.z >= target.position.z)
                    {
                        SetNewDir();
                    }
                }
                else
                {
                    if (transform.position.z <= target.position.z)
                    {
                        SetNewDir();
                    }
                }
            }
        }
       /* if (isforward == true)
        {
            dir = new Vector3(1,0,0);
        }
        else
        {
            dir = new Vector3(-1,0,0);
        }
        */

    }
    private void SetNewDir()
    {
        transform.position = target.position;
        target = nextTarget;
        dir = nextDir;
        if (dir.x != 0)
        {
            dirx = true;
            dirz = false;
        }
        else
        {
            dirx = false;
            dirz = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameManager.instance.ResetScene();
        }
    }
}
