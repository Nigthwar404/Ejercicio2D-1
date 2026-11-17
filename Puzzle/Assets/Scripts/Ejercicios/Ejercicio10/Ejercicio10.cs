using UnityEngine;

public class Ejercicio10 : MonoBehaviour
{
    public float timeMovement;
    public float move;
    public int randomDir;
    public float speed;
    public float timeClone;
    public bool cloned = false;
    public GameObject clone;
    void Update()
    {
        move += Time.deltaTime;
        timeMovement = Random.Range(1f, 2f);
        timeClone += Time.deltaTime;
        


        switch (randomDir)
        {
            case 1:
            if (randomDir ==1)
            {
                gameObject.transform.position += new Vector3(0,0,-1)*speed;
            }
            break;
            case 2:
                if (randomDir ==2)
            {
                gameObject.transform.position += new Vector3(1,0,0)*speed;
            }
            break;
            case 3:
            if (randomDir ==3)
            {
                gameObject.transform.position += new Vector3(0,0,-1)*speed;
            }
            break;
            default:
            if (randomDir ==0)
            {
                gameObject.transform.position += new Vector3(-1,0,0)*speed;
            }
            break;
        }

        if (move >= timeMovement)
        {
            randomDir = Random.Range(0, 3);
            move =0;
            timeMovement=0;
            
        }
        if (timeClone>= 5 && cloned ==false)
        {
            timeClone =0;
            Instantiate(clone, transform.position, transform.rotation);
            cloned = true;
        }

    }
}
