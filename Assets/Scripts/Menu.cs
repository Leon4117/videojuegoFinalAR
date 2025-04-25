using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// cambiar entre escenas
public class Menu : MonoBehaviour
{
    
    public void Play()
    {
        //Va al menu de seleccion 
        //llamamos al metodo junto con el index actual mas 
        TransicionEscenas.Instance.DisolverSalida(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
