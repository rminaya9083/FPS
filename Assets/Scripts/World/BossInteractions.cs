using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossInteractions : MonoBehaviour
{
    private int hitCount = 0;
    public int maxHits = 10;
    public Text winText;  // Referencia al texto de UI para "Ganaste"

    void Start()
    {
        winText.gameObject.SetActive(false);  // Asegúrate de que el texto esté oculto al inicio
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            hitCount++;
            if (hitCount >= maxHits)
            {
                
                StartCoroutine(WinGame());
            }
        }
    }

    IEnumerator WinGame()
    {
        // Desactivar componentes de ataque o movimiento del Boss
        GetComponent<AI>().enabled = false;
        GetComponent<EnemyShoot>().enabled = false;

        winText.gameObject.SetActive(true);  // Mostrar el mensaje "Ganaste"
        yield return new WaitForSeconds(3);  // Esperar 3 segundos

        Destroy(gameObject);  // Destruir el Boss
        SceneManager.LoadScene("MenuInicio");  // Cambiar a la escena del menú principal
    }

}
