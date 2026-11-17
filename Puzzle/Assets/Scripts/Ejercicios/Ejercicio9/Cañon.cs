using Mono.Cecil.Cil;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    //Variable de tiempo para disparar
    public float shootTimer;
    //variable de rango de tiempo para disparar
    public float timerRange;
    //Gameobjet que hace de bala
    public GameObject ammo;
    //direccion en la que aparece la bala para evitar que nazca dentro del cañon
    public Vector3 shootDir;


    // Update is called once per frame
    void Update()
    {
        //timers con rangos aletorios de 0,1 segudos y 2 segundos
        shootTimer = Random.Range(0.1f, 2f);
        timerRange = Random.Range(0.1f, 2f);
        // si el timer es mayor o igual al tiempo de disparar dispara
        if (shootTimer >= timerRange)
        {
            shootDir = new Vector3(0, 1, 0);
            ammo.transform.Translate(shootDir);
            Instantiate(ammo, shootDir, ammo.transform.rotation);
            Debug.Log("He disparado en: " + timerRange + "segundos");

        }
    }
}
