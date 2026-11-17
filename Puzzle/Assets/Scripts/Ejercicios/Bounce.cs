using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Enemy enemy;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && enemy.isforward ==true)
        {
            enemy.isforward= false;
        }
        else
        {
            enemy.isforward = true;
        }
        
    }
}
