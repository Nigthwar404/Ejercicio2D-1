using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public Control c;

    public static ControlsManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        c = new Control();
        c.Enable();
    }
}
