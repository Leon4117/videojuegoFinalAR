using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // por el tipo de letra
using UnityEngine.SceneManagement;
public class MenuSeleccion3D : MonoBehaviour
{
    //referencias personajes
    private int index;
    //referencia a imagen, nombre, game manager
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private TextMeshProUGUI nombre;
    private bool inicio = true;
    private GameManager gameManager;

    public void Start()
    {
        //igal a instancia del scrip
        gameManager = GameManager.Instance;
        //manera de guardar info, nombre del entero
        index = PlayerPrefs.GetInt("SeleccionIndex");
        // mas personajes que index?
        if(index > gameManager.seleccionsCar.Count-1)
        {
            index = 0;
        }
        CambiarSeleccion();
        inicio = false;
    }

    public void CambiarSeleccion()
    {
        //ponga los datos del contenedor basandose en el index
        PlayerPrefs.SetInt("SeleccionIndex", index);
        //image.sprite = gameManager.seleccionsCar[index].imagen;
        if (!inicio)
        {
            GameObject carAnt = GameObject.FindWithTag("Player");
            Destroy(carAnt);
        }
        Instantiate(gameManager.seleccionsCar[index].carroPosible, new Vector3(0, 0, 0), Quaternion.Euler(0,0,0));
        //PrometeoCarController mov = GameObject.FindObjectOfType<PrometeoCarController>();
        //mov.enabled = false;
        nombre.text = gameManager.seleccionsCar[index].nombre;
    }
    public void SigCarro()
    {
        // hay 4, index 5 , vuelve a 0
        if (index == gameManager.seleccionsCar.Count - 1)
        {   
            index =0;
        }else
        {
            //avance
            index += 1;
        }
        //cargar los datos
        CambiarSeleccion();
    }

    public void AntCarro()
    {
        // hay 4 , index -1 , vuelve 4
        if (index == 0)
        {
            // hay 1 , index -1 
            index = gameManager.seleccionsCar.Count - 1;
        }
        else
        {
            index -= 1;
        }
        CambiarSeleccion();
    }

    public void IniciarJuego()
    {
        //carga el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Back()
    {
        Debug.Log("Atras");       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
       
    }
}
