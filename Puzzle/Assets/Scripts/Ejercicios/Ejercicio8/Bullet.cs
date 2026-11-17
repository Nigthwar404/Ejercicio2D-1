using Mono.Cecil;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dist;
    public float fixMove;
    public int dirNum;

    void Update()
    {

        fixMove++;
        if (fixMove >= 100 && dirNum == 0)
        {
            transform.position += Vector3.forward;
            fixMove = 0f;
            Destroy(gameObject,5);
        }
        if (fixMove >= 100 && dirNum == 1)
        {
            transform.position += Vector3.right;
            fixMove = 0f;
            Destroy(gameObject,5);
        }
        if (fixMove >= 100 && dirNum == 2)
        {
            transform.position += Vector3.left;
            fixMove = 0f;
            Destroy(gameObject,5);
        }
        if (fixMove >= 100 && dirNum == 3)
        {
            transform.position += Vector3.back;
            fixMove = 0f;
            Destroy(gameObject,5);
            
        }
        
    }
    
}
