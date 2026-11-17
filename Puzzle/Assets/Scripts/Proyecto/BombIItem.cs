using UnityEngine;

public class BombIItem : MonoBehaviour
{
    public PlayerMovement thePlayer;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAbilites pA;
            pA = other.GetComponent<PlayerAbilites>();
            pA.canPlaceBomb = true;
            Destroy(gameObject);
        }
    }
}
