using UnityEngine;

public class Key : MonoBehaviour
{
    void Start()
    {
        anim = GetComponent<Animator>();
        //si la llave esta en la escena indica en el GM que se tiene que recoger
        GameManager.instance.collectKey = true;
    }
    public Animator anim;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   //le decimos al manager que hemos cogido una llave.
            
            //Activa el trigger del animator
            anim.SetTrigger("Collect");
            GameManager.instance.key = true;



        }
    }
    //este void se ejecuta desde la animacion
    public void EndKey()
    {
        Destroy(gameObject);
    }
}
