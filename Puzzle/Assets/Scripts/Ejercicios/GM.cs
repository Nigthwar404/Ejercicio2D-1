using UnityEngine;
using TMPro;
public class GM : MonoBehaviour
{
    public float monedas;
    public int pasos;
    // referencia al objeto que muestra la cantidad e monedas del jugador
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI stepText;

   public static GM gM;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
   void Awake()
    {
        if (gM == null)
        {
            gM = this;
        }
        //Singleton
    }
    public void AddCoin(int amount)
    {
         monedas +=amount;
         coinsText.text = "Monedas: " + monedas;
         
    }
    public void AddSteps(int cantidad)
    {
        pasos += cantidad;
        stepText.text = "Pasos: " + cantidad;
    }
    
}
