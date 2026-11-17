using UnityEngine;

public class ChangeEnemyDir : MonoBehaviour
{
    //Nueva direccion que va a tener el enemigo
    public Vector3 newDir;
    //siguiente posicion a la que se va a mover el enemigo despues de llegar a la posicion en la que este el objeto del script
    public Transform NextChangeEnemyDir;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //crea a la variable local para guardar el script del enemigo
            Enemy enemy = other.GetComponent<Enemy>();
            //pasamos al script del enemigo el siguiente punto al que ir
            enemy.nextTarget = NextChangeEnemyDir;

            enemy.nextDir = newDir;
            Debug.Log("Se ha cambiado el target");
        }
        
    }
}
