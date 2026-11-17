using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Range sirve para que el numero que hay dentro de la variable este entre dos numeros indicados
    [Range(0, 3)]
    //cantidad de veces que se ha de pisar un bloque
    public int steps;
    public MeshRenderer mR;
    // Material cuando solo hay que pisar un bloque una vez
    public Material oneStep;
    public Material twoSteps;
    public Material threeSteps;

    public Material worldMaterial;

    void Start()
    {
        mR= GetComponent<MeshRenderer>();
        //al pulsar play compruebo el material del bloque, para evitar contar bloques completos
        if (mR.material != worldMaterial)
        {
            if (mR.material != worldMaterial)
            {
                GameManager.instance.totalBlock++;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("el jugador ha entrado en el bloque");
            //cambia el material
            if (steps > 0)
            {
                steps--;
                switch (steps)
        {
            case 3:
                mR.material = threeSteps;
                break;
            case 2:
                mR.material = twoSteps;
                break;
            case 1:
                mR.material = oneStep;
                break;
            default:
            //indicamos al GM que se ha completado un bloque
                GameManager.instance.currentBlocks++;
                mR.material = worldMaterial;
                break;
        }
            }
            CheckSteps();
            /*
                        if (steps ==2)
                        {
                            mR.material = twoSteps;
                        }
                        else if (steps==1)
                        {
                            mR.material = oneStep;
                        }
                        else
                        {
                            mR.material = worldMaterial;
                        }
                        */

        }
    }
    private void CheckSteps()
    {
        

    }
}
