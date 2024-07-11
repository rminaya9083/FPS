using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{

    public void LoadMenu()
    {
        // Carga la escena del menú principal. Asegúrate de que el nombre de la escena es correcto.
        SceneManager.LoadScene("MenuInicio");
    }

    public void Nivel1()    {
        
        SceneManager.LoadScene("Nivel1");
    }

    public void Boss()
    {

        SceneManager.LoadScene("Nivel#1");
    }    
    
    public void Mundos()
    {

        SceneManager.LoadScene("Mundos");
    }


    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
