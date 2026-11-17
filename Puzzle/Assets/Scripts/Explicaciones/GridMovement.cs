using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class GridMovement : MonoBehaviour
{
    private Controls control;
    //Distancia que se movera el cubo
    public float distance;
    public float rightLimit;
    public float backLimit;
    public float forwardLimit;
    public float leftLimit;
    public bool isUpgraded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        control = new Controls();
        //Forma de activar todos los controles
        control.Enable();

        /*desactivar todos los controles
        control.Disable();
        desactiva los controles solo de world.
        control.world.disable();
        Funciona tambien para activar solo world
        control.world.enable();
        */
        control.World.MoveForward.performed += MoveForward;
        control.World.MoveBack.performed += MoveBack;
        control.World.MoveRigth.performed += MoveRigth;
        control.World.MoveLeft.performed += MoveLeft;
        control.World.MoveUpgrade.performed += MoveUpgrade;
    }
    //Forma de mover un objeto en unity en grid, es decir de uno en uno en 3 direcciones
    //transform se refiere al transform que se ve en el inspector del objeto que lleva el script
    //desde el transform podemos acceder a la posicion del objeto y sumarle 1 en Z
    void MoveForward(InputAction.CallbackContext x)
    {
        if (transform.position.z + distance <= forwardLimit)
        {
            transform.position += Vector3.forward * distance;
        }
        else
        {
            Debug.Log("El jugaor ha llegado al limite superior");
        }
        
    }
    void MoveBack(InputAction.CallbackContext x)
    {
        if (transform.position.z - distance >= backLimit)
        {
            transform.position += Vector3.back * distance;
        }
        else
        {
            Debug.Log("El jugador ha llegado al inferior");
        }
        
    }
    void MoveRigth(InputAction.CallbackContext x)
    {
        if (transform.position.x + distance <= rightLimit)
        {
            transform.position += Vector3.right * distance;

        }
        else
        {
            Debug.Log("El jugador ha llegado al limite derecho");
        }

    }
    void MoveLeft(InputAction.CallbackContext x)
    {
        if (transform.position.x - distance >= leftLimit)
        {
            transform.position += Vector3.left * distance;
        }
        else
        {
            Debug.Log("El jugador ha llegado al limite izquierdo");
        }
        
    }
    void MoveUpgrade(InputAction.CallbackContext x)
    {

        /* otra forma de hacer los if sin la booleana o abreviar los if es 
        distance= distance == 1.5f ? distance * 2 : distance /2;
        */
        if (!isUpgraded)
        {
            isUpgraded = true;
            distance = distance * 2;
        }
        else
        {
            isUpgraded = false;
            distance = 1.5f;
        }

    }
}
