using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Carga la siguiente escena; asegúrate de actualizar el nombre de la escena a la correcta
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
