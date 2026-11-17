using Unity.VisualScripting;
using UnityEngine;

public class MoveCollider : MonoBehaviour
{
    public bool canMove=true;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Box"))
        {
            canMove = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            canMove=true;
        }
        if (other.CompareTag("Box"))
        {
            canMove=true;
        }
    }
}

