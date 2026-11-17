using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class EfectoPariposaEj11 : MonoBehaviour
{
    public float time;
    public float timeToMove;
    public float changecolor;
    public int dist;
    public bool GoingDown;
    public bool noMoreColor;
    public bool end;
    public float ScaleTimer;
    public Renderer renderer;
    public int colorGenerator1;
    public List<Color> colores;
    public int limiteLista;

    // Update is called once per frame
    void Start()
    {
        limiteLista = 200;
        while (colores.Count < limiteLista)
        {
            Color nuevoColor = Random.ColorHSV();
            if (!colores.Contains(nuevoColor))
            {
                colores.Add(nuevoColor);
            }
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        dist = Random.Range(2, 5);
        changecolor += Time.deltaTime;
        colorGenerator1 =Random.Range(0,limiteLista);
        ScaleTimer+= Time.deltaTime;


        if (time >= timeToMove && GoingDown == false)
        {
            time = 0;
            gameObject.transform.position += Vector3.up * dist;
        }
        if (gameObject.transform.position.y >= 20)
        {
            GoingDown = true;
            noMoreColor = true;
        }
        if (changecolor >= 0.1f && noMoreColor == false)
        {
            changecolor = 0f;
            renderer.material.color = colores[colorGenerator1];
            colores.RemoveAt(colorGenerator1);
            limiteLista--;

        }
        if (GoingDown == true && time >= timeToMove && end == false)
        {
            time = 0;
            renderer.material.color = Color.red;
            gameObject.transform.position += Vector3.down * dist;

        }
        if (GoingDown == true && ScaleTimer >= 0.2f)
        {
            ScaleTimer = 0;
            transform.localScale *= 1.5f;
        }
        if (gameObject.transform.position.y <= 0 && GoingDown == true)
        {
            end = true;
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }
}
