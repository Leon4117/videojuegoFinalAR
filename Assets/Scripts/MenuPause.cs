using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuPause : MonoBehaviour
{
    //variables de objetos
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuPuntos;
    [SerializeField] private GameObject buttonResume;
    //para boton de teclado 
    public bool gamePause = false;

    private void Update()
    {
        /* (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePause)
            {
                Resume();
            }
            else { 
                Pause();
            }
        }*/
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);
        gamePause = true;
        Musica.Instance.PausarMusic();

        Debug.Log("Pausaaaaa");
    }

    public void Resume() {
        Time.timeScale = 1f;
        //activar pausa
        buttonPause.SetActive(true);
        // descativar menu
        menuPause.SetActive(false);
        gamePause = false;
        Musica.Instance.ReanudarMusic();
        Debug.Log("Resumen");
    }

    public void Restart()
    {
        Time.timeScale = 1f; 
        //recargamos la escena (name)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gamePause = false;
    }

    public void Quit()
    {
        Debug.Log("Cerrar juego");
        Time.timeScale = 1f;//tiempo de juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Musica.Instance.CambiarMenu(Musica.Instance.menuMusic);
        gamePause = false;
    }

    public void BackSeleccion()
    {
        Debug.Log("Seleccionar carro");
        Time.timeScale = 1f;//tiempo de juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Musica.Instance.CambiarMenu(Musica.Instance.menuMusic);
    }
    //solo para ver si los puntos se estan modificando
    public void Prueba()
    {
        //desactivar boton pausa
        buttonPause.SetActive(false);
        //activar menu
        menuPuntos.SetActive(true);
    }
}
