using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public  Vector3 shootDir;
    //Objeto que vamos a hacer que aparezca en la escena desde el script
    public GameObject canonBall;
    public float elapsedTime;
    public float shootTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= shootTime)
        {
            elapsedTime = 0f;
            //forma de hacer que aparezca un objeto en la escena desde codigo
            //1- Objeto que va a parecer en la escena
            //2-posicion donde se genra
            //3- rotacion
            //El objeto que se acaba de generar se guarda en la variable "newCanBall
            GameObject newCanonBall = Instantiate(canonBall, transform.position, canonBall.transform.rotation);
            //Creamos una variable donde guardamos el script Enemy de la bala que acabamos de generar
            Enemy enemyComponent = newCanonBall.GetComponent<Enemy>();
            enemyComponent.cannonBall = true;
            enemyComponent.dir = shootDir;
        }
    }
}
