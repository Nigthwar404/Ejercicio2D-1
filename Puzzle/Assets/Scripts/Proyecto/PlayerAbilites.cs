using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerAbilites : MonoBehaviour
{
    public GameObject bomb;
    public GameObject helmet;
    public List<GameObject> hats;
    public int currenthat;
    public int totalHats;
    public bool canPlaceBomb;
    public bool gotHelmet;
    public bool equiped;
    public bool vanish = false;
    private Controls c;
    public PlayerMovement player;
    public MeshRenderer mR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        hats = new List<GameObject>(10);
        mR.enabled = true;
        c = new Controls();
        c.Enable();
        c.World.ExtraSkill1.performed += HelmetSwap;
        c.World.ExtraSkill2.performed += Vanish;
        c.World.PreviousHat.performed += PreviousHat;
        c.World.NextHat.performed += NextHat;
    }
    void Start()
    {
        currenthat = 0;
        c.World.Bomb.performed += PlaceBomb;
    }

    // Update is called once per frame
    void Update()
    {
        if (vanish == true)
        {
            helmet.SetActive(false);
        }
        if (currenthat >= totalHats)
        {
            currenthat = totalHats - 1;
        }
        if (currenthat <= 0)
        {
            currenthat = 0;
        }

    }
    public void PlaceBomb(InputAction.CallbackContext x)
    {
        if (canPlaceBomb == true)
        {
            canPlaceBomb = false;
            Instantiate(bomb, transform.position, bomb.transform.rotation);
        }
    }
    void HelmetSwap(InputAction.CallbackContext x)
    {
        if (gotHelmet == true)
        {
            if (equiped == true)
            {
                equiped = false;
                helmet.SetActive(false);
            }
            else
            {
                equiped = true;
                helmet = hats[currenthat];
                helmet.transform.position = player.head.transform.position;
                helmet.SetActive(true);
            }

            if (hats[currenthat])
            {
                helmet = hats[currenthat];

            }

        }



    }
    void Vanish(InputAction.CallbackContext x)
    {
        if (vanish == false)
        {
            vanish = true;
            mR.enabled = false;

        }
        else
        {
            vanish = false;
            mR.enabled = true;
        }

    }
    void PreviousHat(InputAction.CallbackContext x)
    {
        if (currenthat <= 0)
        {
            currenthat = 0;
        }
        if (currenthat >= 10)
        {
            currenthat = 10;
        }
        if (currenthat >= 0 || currenthat <= hats.Count - 1)
        {
            currenthat--;
        }
    }
    void NextHat(InputAction.CallbackContext x)
    {
        if (currenthat <= 10 || currenthat >= hats.Count + 1)
        {
            currenthat++;
        }
    }
    void OnDestroy()
    {
        c.Disable();
    }
}
