using System.Collections.Generic;
using UnityEngine;

public class HelmetProvider : MonoBehaviour
{
    public GameObject hatToAdd;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAbilites pA;
            pA =other.GetComponent<PlayerAbilites>();
            pA.hats.Add(hatToAdd);
            pA.totalHats++;
            pA.gotHelmet = true;
            Destroy(gameObject);
        }
    }
}
