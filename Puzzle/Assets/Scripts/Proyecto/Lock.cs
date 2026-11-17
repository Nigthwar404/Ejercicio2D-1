using UnityEngine;

public class Lock : MonoBehaviour
{
    public Animator anim;
    public FinalBlock fB;
    void Start()
    {
        
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& GameManager.instance.key)
        {
            anim.SetTrigger("OpenLock");
            Debug.Log("Has abierto el candado");
        }
        else
        {
            Debug.Log("Te falta la llave");
        }
    }
    public void endLock()
    {
        fB.lockOpened=true;
        gameObject.SetActive(false);
    }
}
