using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text ammoText;

    public static GameManager Instance { get; private set; }

    public int gunAmmo = 15;


    public Text healthText;

    public int health = 100;

    public int maxHealth = 100;

    public int healthBoss = 100;

    public int maxHealthBoss = 100; 

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text= health.ToString();
    }

    public void LoseHealth(int healthToReduce)
    {
        health -= healthToReduce;
        Checkheatlh();
    }

    public void Checkheatlh()
    {
        if (health <= 0)
        {
            Debug.Log("Has Muerto");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddHealth(int heatlh)
    {
        if (this.health + heatlh >= maxHealth)
        {
            this.health = 100;
        }
        else
        {
            this.health += heatlh;
        }
    }

}
