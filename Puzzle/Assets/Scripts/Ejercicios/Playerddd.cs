using UnityEngine;
using UnityEngine.InputSystem;

public class Playerddd : MonoBehaviour
{
    ControlEJ controles;
    public bool reverse;
    public float distance;
    public int steps;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controles = new ControlEJ();
        controles.Enable();

        controles.World.Up.performed += MoveUp;
        controles.World.Down.performed += MoveDown;
        controles.World.Boost.performed += BoostMove;
        controles.World.Reverse.performed += ReverseMove;
    }

    // Update is called once per frame
   public void MoveUp(InputAction.CallbackContext x)
    {
        transform.position += Vector3.up * distance;
         steps ++;;
         GM.gM.AddSteps(steps);
    }
    public void MoveDown(InputAction.CallbackContext x)
    {
        transform.position += Vector3.down * distance;
        steps++;
         GM.gM.AddSteps(steps);

    }
    public void BoostMove(InputAction.CallbackContext x)
    {
        
        if(reverse)
        {
            distance = -distance * 3;
        }
        else
        {
            distance= distance == 1 ? distance = 3 : distance /3;
        }
    }
    public void ReverseMove(InputAction.CallbackContext x)
    {
        if (!reverse)
        {
            reverse = true;
            distance = -distance;
        }
        if(reverse)
        {
            reverse = false;
            distance = +distance;
        }
    }
}
