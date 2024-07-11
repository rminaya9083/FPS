using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pausedPanel;


    private bool isGamePaused = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isGamePaused = ! isGamePaused;
            PausedGame();  
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("MenuInicio");
        }
    }

    public void PausedGame()
    {
        if (!isGamePaused)
        {
            Time.timeScale = 0;

            pausedPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;

            pausedPanel.SetActive(false);
        }
    }

}
