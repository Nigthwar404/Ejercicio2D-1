using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
    public float autodestructTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,autodestructTime);
    }

    
}
