using UnityEngine;
using UnityEngine.UIElements;

public class LaBala : MonoBehaviour
{
    public float timeToDestroy;
    public int dist;
    public int dirNum;
    public float move;
    // Update is called once per frame
    void Update()
    {
        move += Time.deltaTime;
        timeToDestroy += Time.deltaTime;
        if (move >= 0.5f)
        {
            switch (dirNum)
            {
                case 0:
                    transform.Translate(Vector3.forward);
                    move = 0f;
                    break;
                case 1:
                    transform.Translate(Vector3.right);
                    move = 0f;
                    break;
                case 2:
                    transform.Translate(Vector3.left);
                    move = 0f;
                    break;
                case 3:
                    transform.Translate(Vector3.back);
                    move = 0f;
                    break;

            }
        }

        if (timeToDestroy >= 20)
        {
            Destroy(gameObject);
        }
    }
}
