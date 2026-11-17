using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ejercicio11 : MonoBehaviour
{
    Ej11Controll controll;
    public GameManager Ej11manager;
    public int dist;

    void Start()
    {
        controll = new Ej11Controll();
        controll.Enable();

        controll.World.Forward.performed += MoveForward;
        controll.World.Rigth.performed += MoveRight;
        controll.World.Left.performed += MoveLeft;
        controll.World.Back.performed += MoveBack;
    

    }
    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void MoveForward(InputAction.CallbackContext x)
    {
        transform.position += Vector3.forward * dist;
    }
    public void MoveRight(InputAction.CallbackContext x)
    {
        transform.position += Vector3.right * dist;
    }
    public void MoveLeft(InputAction.CallbackContext x)
    {
        transform.position += Vector3.left * dist;
    }
    public void MoveBack(InputAction.CallbackContext x)
    {
        transform.position += Vector3.back * dist;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Candado"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
