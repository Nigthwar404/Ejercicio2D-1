using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int add;
    public MeshRenderer mR;
    public Material mT;
    // cc = color change
    public bool cC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //se accede al GM gracias al SINGLETON y sumamos 1 a la variable monedas
        //GM.gM.monedas += add;
        if (GM.gM.monedas < 0)
        {
            GM.gM.monedas = 0;
        }
        Debug.Log(other.name + " Ha tocado la moneda");
        /* Comprueba que el jugador se haya cocado con la moneda
        forma 1: comprobar tag
        */
        if (other.tag == "Player")
        {
            Debug.Log("Cambio de color");
            mR.material = mT;
            
        }
        if(other.tag=="Player" && cC)
        {
            GM.gM.monedas += Random.Range(1,100);
            GM.gM.AddCoin(add);
            
            Destroy(gameObject);
        }


    }
    void OnTriggerExit(Collider other)
    {
        cC =true;
    }
}
