using System;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float vertialRange;
    public Transform shootPosRigth;
     public Transform shootPosLeft;
    public float speed;
    public Vector2 dir;
    public Vector2 direction;
    public GameObject bullet;
    public Bullet bS;


    void Start()
    {
        ControlsManager.instance.c.World.ShootRigth.performed += ShootRigth;
        ControlsManager.instance.c.World.ShootLeft.performed += ShootLeft;

    }
    // Update is called once per frame
    void Update()
    {
        dir = ControlsManager.instance.c.World.Dir.ReadValue<Vector2>();

        transform.Translate(dir * speed * Time.deltaTime);
        BorderLimit();

    }
    private void BorderLimit()
    {
        if (transform.position.y >= vertialRange)
        {
            transform.position = new Vector3(transform.position.x, vertialRange, transform.position.z);
        }
        else if (transform.position.y <= -vertialRange)
        {
            transform.position = new Vector3(transform.position.x, -vertialRange, transform.position.z);
        }
    }

    private void ShootRigth(InputAction.CallbackContext x)
    { 
        bS.bulletdir= direction;
        Instantiate(bullet, shootPosRigth.position, bullet.transform.rotation);
        
    }
    private void ShootLeft(InputAction.CallbackContext x)
    {
        bS.bulletdir= direction;
        Instantiate(bullet, shootPosLeft.position,bullet.transform.rotation );
        
    }
}
