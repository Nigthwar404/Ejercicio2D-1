using Unity.VisualScripting;
using UnityEngine;

public class Water : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("He chocado con el agua");
        if (other.CompareTag("Player"))
        {
            //variable local que solo se puede acceder en este if
            int n = 10;
            //creamos un animator en local para poder accder al animator del jugador para hacer el death al tocar agua
            //para hacer esto necesitamos crear las variables locales de anim
            Animator anim;
            anim = other.GetComponent<Animator>();
            anim.SetBool("Death",true);
            

            //Ejemplo de que se puede hacer con cualquier otro componente o script
            //PlayerMovement pM;

            //pM = other.GetComponent<PlayerMovement>();
            //pM.distance = other.getcomponent<PlayerMovement>();
            //pM.distance = 10;
        }
    }

}
