using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Transactions;

public class GameManager : MonoBehaviour
{
    // cuenta las monedas que ha recogido el jugador
    public int coins;
    //Cantidad de bloques que tiene que pulsar el jugador en el nivel
    public int totalBlock;
    //cantidad de bloques que ha completado el jugador
    public int currentBlocks;
    public int levelCoins;
    public bool key;
    // si true el nivel tiene una llave que recoger
    public bool collectKey;
    public bool bomb;
    public int currentScene;
    public float deathCd;
    public GameObject finalScreen;

    public TextMeshProUGUI coinsText;

    //Singleton.
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Esta linea hace que el GM no se destruya al cargar un escena o pasar de nivel
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Singleton
    }
    //TO DO  terminar el switch para asegurar que el total block se ajuste al nivel
    void Update()
    {
        /*
        switch (totalBlock)
        {
            case 0:
            if (currentScene == 1 && totalBlock >=12)
            {
                totalBlock = 11;
            }
            break;
            case 1:
            if (currentScene == 2 && totalBlock >=12)
            {
                totalBlock = 11;
            }
            break;
        }*/
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void addCoins(int amount)
    {
        if (levelCoins + amount >= 0)
        {
            levelCoins += amount;
        }
        coins += amount;
        coinsText.text = "Monedas " + (coins + levelCoins);
    }
    public void NextLevel()
    {
        currentScene++;
        totalBlock = 0;
        currentBlocks = 0;
        levelCoins = 0;
        key = false;
        collectKey = false;
        ResetValues();
        if (currentScene >= SceneManager.sceneCountInBuildSettings)
        {
            finalScreen.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(currentScene);
        }

    }

    //las corrutinas son funciones de unity 

    
    public void ResetScene()
    {
        ResetValues();

        //forma de llamar a una corutina
        //si no pongo startcorutine no va a funcionar aunque no de error de codigo
        StartCoroutine(DeathCooldown());

    }
    private IEnumerator DeathCooldown()
    {
        yield return new WaitForSeconds(deathCd);
        SceneManager.LoadScene(currentScene);
        coinsText.text = "Monedas " + (coins + levelCoins);
    }

    public void ResetValues()
    {
        totalBlock = 0;
        currentBlocks = 0;
        levelCoins = 0;
        key = false;
        collectKey = false;
    }
    public void ResetVideogame()
    {
        finalScreen.SetActive(false);
        ResetValues();
        SceneManager.LoadScene(currentScene);
        coinsText.text = "Monedas: " + (coins + levelCoins);
    }

    public void ExitVideogame()
    {
        Application.Quit();
    }

}
