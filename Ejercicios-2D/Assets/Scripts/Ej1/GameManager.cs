using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Canvas;
    public TextMeshProUGUI Vidas;
    public int hp;
    public TextMeshProUGUI Puntos;
    public int score;
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void AddPoints()
    {
        score += 5;
        Puntos.text = "Puntos : " + (score);
    }
    public void RemoveLife()
    {
        hp -=1;
        Vidas.text = "Vidas : " + (hp);
    }
}
