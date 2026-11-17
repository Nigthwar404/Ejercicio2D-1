using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class PlayerGridShot : MonoBehaviour
{
    ControlEJ8 controll;
    public int dist;
    public int speed;
    public Vector3 shootDir;
    public GameObject bala;
    void Start()
    {
        controll = new ControlEJ8();
        controll.Enable();

        controll.World.Forward.performed += MoveUp;
        controll.World.Rigth.performed += MoveRight;
        controll.World.Left.performed += MoveLeft;
        controll.World.Back.performed += MoveBack;
        controll.World.Sforward.performed += ShootUp;
        controll.World.Srigth.performed += ShootRight;
        controll.World.Sleft.performed += ShootLeft;
        controll.World.Sback.performed += ShootBack;
    }

    public void MoveUp(InputAction.CallbackContext x)
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
    public void ShootUp(InputAction.CallbackContext x)
    {
        shootDir = new Vector3(0, 0, 1) + gameObject.transform.position;
        GameObject newBullet = Instantiate(bala, shootDir, transform.rotation);
        newBullet.GetComponent<Bullet>().dirNum = 0;
        
    }
    public void ShootRight(InputAction.CallbackContext x)
    {
        shootDir = new Vector3(1, 0, 0) + gameObject.transform.position;
        GameObject newBullet = Instantiate(bala, shootDir, transform.rotation);
        newBullet.GetComponent<Bullet>().dirNum = 1;
        
    }
    public void ShootLeft(InputAction.CallbackContext x)
    {
        shootDir = new Vector3(-1, 0, 0) + gameObject.transform.position;
        GameObject newBullet = Instantiate(bala, shootDir, transform.rotation);
        newBullet.GetComponent<Bullet>().dirNum = 2;
    }
    public void ShootBack(InputAction.CallbackContext x)
    {
        shootDir = new Vector3(0, 0, -1) + gameObject.transform.position;
        GameObject newBullet = Instantiate(bala, shootDir, transform.rotation);
        newBullet.GetComponent<Bullet>().dirNum = 3;
    }

}
