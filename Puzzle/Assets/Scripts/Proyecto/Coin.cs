using Unity.Mathematics;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinsToAd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.addCoins(coinsToAd);
            // GameManager.instance.addCoins(coinsToAd);
            //GameManager.instance.addCoins(coinsToAd);
            Destroy(gameObject);
        }
        //se accede al GM gracias al SINGLETON y sumamos 1 a la variable monedas

        Debug.Log(other.name + " Ha tocado la moneda");
        /* Comprueba que el jugador se haya cocado con la moneda
        forma 1: comprobar tag
        */






    }
}
