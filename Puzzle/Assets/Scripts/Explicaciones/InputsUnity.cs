using UnityEngine;
using UnityEngine.InputSystem;//libreria para trabajar mejor con el input sistem nuevo de unity

public class InputsUnity : MonoBehaviour
{

// la referencia al principio esta y se tiene que usar el contructor
    private Controles controles;
    // Start is called once before the first execution ofS Update after the MonoBehaviour is created
    void Start()
    {
        // Se tiene que hacer esto para trabajar con el sistema de inputs
        // al hacer "nombre de variable" = new "nombre"(); se crea el constructor
        controles = new Controles();
        //activa los controles porque por defecto estan desactivados
        controles.Enable();
        //Al empezar el juego indicamos a unity que cuando se pulse la tecla asiganada en moveForward en los controles haga lo que pone entre dos llaves 
        //esto equivale a input.getkeydown

        /*
        controles.World.MoveForward.performed += (x) =>
        {
            Debug.Log("Se ha pulsado al tecla move forward");
            
        };
        //esto sirve para cuando dejas de pulsar la accion de moveForward, es igual a input.getkeyup
        controles.World.MoveForward.canceled += (x) =>
        {
          Debug.Log("Has dejado de mover la tecla MoveForward");  
        };
        */  
        //forma 2
        // le decimos a moveForward que void tiene que ejecutar cuando se pulsa la tecla     
        controles.World.MoveForward.performed += moveForward;
        //En la forma 2 puedo quitar una funcion de los controles mientras que en la forma 1 no
        //controles.World.MoveForward.performed -= moveForward;
    }

    // Update is called once per frame
    void Update()
    {/* equivale a si la tecla esta siendo presionada.
        equivale a input.getkey.
        if (controles.World.MoveForward.IsPressed())
        {
            
        }
        */
    }
public void moveForward(InputAction.CallbackContext x)
    {
        Debug.Log("MoveWorward");
    }
}
