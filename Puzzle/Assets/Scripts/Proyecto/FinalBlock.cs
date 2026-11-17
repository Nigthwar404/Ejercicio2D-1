using UnityEngine;

public class FinalBlock : MonoBehaviour
{
    private bool key = false;
    public bool lockOpened = false;
    public GameObject LockGo;
    public static FinalBlock instance;


    void Update()
    {
        if (GameManager.instance.currentBlocks >= GameManager.instance.totalBlock && GameManager.instance.collectKey)
        {
            LockGo.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //comprobacion de si es necesario que el jugador consiga la llave
        if (other.CompareTag("Player"))
        {
            //comprobacion de si se tiene que recoger y si ha sido recogida la llave
            if (GameManager.instance.collectKey && GameManager.instance.key)
            {
                key = true;
                Debug.Log("Se ha recogido la llave");
            }
            else
            {
                if (GameManager.instance.collectKey)
                {
                    key = false;
                }
            }
        }
        //Comprueba si se han pisado todas las plataformas y si se cumple la condicion de llave
        if (GameManager.instance.currentBlocks >= GameManager.instance.totalBlock && GameManager.instance.collectKey == false )
        {
            Debug.Log("Victoria");
            LockGo.SetActive(true);
            GameManager.instance.NextLevel();
        }
        else if (GameManager.instance.currentBlocks >= GameManager.instance.totalBlock && lockOpened)
        {
            Debug.Log("Victoria");
            GameManager.instance.NextLevel();
        }
        else
        {
            Debug.Log("Faltan requisitos");
        }

    }
    /*
    void OnTriggerEnter(Collider other)
    {
        //comprobamos si el jugador tenia que recoger la llave y si la ha recogido
        if (other.CompareTag("Player"))
        {
            //comprobamos si tenemos la llave, se pueden quitar los "== true"
            if (GameManager.instance.collectKey == true && GameManager.instance.key == true)
            {
                key = true;
                Debug.Log("Se ha recogido la llave.");
                // LockGo.SetActive(true);
            }
            else
            {
                // comprueba si el jugor no tenia que coger la llave
                if (GameManager.instance.collectKey)
                {
                    key = false;
                    //LockGo.SetActive(true);
                }
            }


        }
        // comprueba si se han pisado todas las plataformas y si se cumple la condicion de la llave
        if (GameManager.instance.currentBlocks >= GameManager.instance.totalBlock && GameManager.instance.key ==false)
        {
            Debug.Log("Victoria");
            LockGo.SetActive(true);
            GameManager.instance.NextLevel();
        }
        else if (GameManager.instance.currentBlocks >= GameManager.instance.totalBlock && GameManager.instance.key )
        {
            Debug.Log("Victoria");
            LockGo.SetActive(true);
            GameManager.instance.NextLevel();
        }
        else
        {
            Debug.Log("Falta por completar algun objetivo");
        }
    }
    void Update()
    {
        if (GameManager.instance.totalBlock == GameManager.instance.currentBlocks && lockOpened == false && GameManager.instance.collectKey == true)
        {
            LockGo.SetActive(true);
        }
    }*/
}
