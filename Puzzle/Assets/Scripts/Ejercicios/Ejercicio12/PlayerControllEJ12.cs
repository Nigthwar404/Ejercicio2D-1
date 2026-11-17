using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllEJ12 : MonoBehaviour
{
    EJ12Controll controll;
    public int dir;
    public float Move;
    public float TimeToMove;
    public GameObject Labala;
    public Vector3 shootDir;
    public GameObject shootPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controll = new EJ12Controll();
        controll.Enable();

        controll.World.Forward.performed += MoveForward;
        controll.World.Right.performed += MoveRight;
        controll.World.Left.performed += MoveLeft;
        controll.World.Back.performed += MoveBack;
        controll.World.Shoot.performed += Shoot;

    }

    // Update is called once per frame
    void Update()
    {
        Move += Time.deltaTime;
        if (Move >= TimeToMove)
        {
            switch (dir)
            {
                case 0:
                    {
                        transform.Translate(Vector3.forward);
                        Move = 0f;
                        break;
                    }
                case 1:
                    {
                        transform.Translate(Vector3.right);
                        Move = 0f;
                        break;
                    }
                case 2:
                    {
                        transform.Translate(Vector3.left);
                        Move = 0f;
                        break;
                    }
                case 3:
                    {
                        transform.Translate(Vector3.back);
                        
                        Move = 0f;
                        break;
                    }


            }
        }


    }
    // desde aqui hasta el final es movimiento cada uno con su boton (W,A,S,D) y disparo(LeftClick)
    void MoveForward(InputAction.CallbackContext x)
    {
        //le doy dir para que sepa que direccion es la suya en este caso Forward
        dir = 0;
        //le digo a la posicion de disparo que se desplaze 1 casilla por delante del player para evitar que salga de el.
        //en este caso es posicion de disparo + posicion de player en esa direccion
        shootPos.transform.position = new Vector3(0,0,1) + gameObject.transform.position;
    }
    void MoveRight(InputAction.CallbackContext x)
    {
        dir = 1;
        shootPos.transform.position = new Vector3(1,0,0) + gameObject.transform.position;
    }
    void MoveLeft(InputAction.CallbackContext x)
    {
        dir = 2;
        shootPos.transform.position = new Vector3(-1,0,0) + gameObject.transform.position;
    }
    void MoveBack(InputAction.CallbackContext x)
    {
        dir = 3;
        shootPos.transform.position = new Vector3(0,0,-1) + gameObject.transform.position;
    }
    void Shoot(InputAction.CallbackContext x)
    {
        //se instancia la bala y se le da una direccion gracias al dir anterior asi jugador y bala siempre van al mismo sitio
        GameObject newBullet = Instantiate(Labala, shootPos.transform.position, transform.rotation);
        newBullet.GetComponent<LaBala>().dirNum = dir;
        //Instantiate(Labala,transform.position, transform.rotation);
    }
}
