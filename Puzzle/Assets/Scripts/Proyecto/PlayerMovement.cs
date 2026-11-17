using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private GameControll managemove;
    public float distance = 2;
    public bool bomb;
    public GameObject head;
    public MoveCollider colForward;
    public MoveCollider colRight;
    public MoveCollider colLeft;
    public MoveCollider colBack;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        managemove = new GameControll();
        managemove.Enable();



        managemove.World.Foward.performed += MoveForward;
        managemove.World.Left.performed += MoveLeft;
        managemove.World.Rigth.performed += MoveRigth;
        managemove.World.Back.performed += MoveBack;
        managemove.World.Salir.performed += Salir;


    }


    //Forma de mover un objeto en unity en grid, es decir de uno en uno en 3 direcciones
    //transform se refiere al transform que se ve en el inspector del objeto que lleva el script
    //desde el transform podemos acceder a la posicion del objeto y sumarle 1 en Z
    void MoveForward(InputAction.CallbackContext x)
    {
        if (colForward.canMove)
        {
            transform.position += Vector3.forward * distance;
        }

    }
    void MoveBack(InputAction.CallbackContext x)
    {
        if (colBack.canMove)
        {
            transform.position += Vector3.back * distance;
        }
    }
    void MoveRigth(InputAction.CallbackContext x)
    {
        if (colRight.canMove)
        {
            transform.position += Vector3.right * distance;
        }
    }
    void MoveLeft(InputAction.CallbackContext x)
    {
        if (colLeft.canMove)
        {
            transform.position += Vector3.left * distance;
        }
    }
    void OnDestroy()
    {
        managemove.Disable();
    }
    public void Death()
    {
        GameManager.instance.ResetScene();
    }
    void Salir(InputAction.CallbackContext x)
    {
        Application.Quit();
    }


}
