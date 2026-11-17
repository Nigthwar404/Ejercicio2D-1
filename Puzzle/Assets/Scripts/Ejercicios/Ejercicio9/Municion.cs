
using UnityEngine;
using UnityEngine.UIElements;

public class Municion : MonoBehaviour
{
    public int speed;
    public float colorTimer;
    public Renderer colorToChange;
    public int randomNumber;

    public void Start()
    {
        colorToChange = GetComponent<Renderer>();
    }

    void Update()
    {
        colorTimer += Time.deltaTime;
        
        if (colorTimer>= 0.5f)
        {
            colorTimer=0f;
            colorToChange.material.color = Random.ColorHSV();
        }

        transform.Translate(speed*gameObject.transform.position*Time.deltaTime);
        if (gameObject.transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }
}
