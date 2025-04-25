using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.Playables;
public class Puntaje : MonoBehaviour
{
    //estos puntos se los deben pasar del "Player"
    private float[] puntos = new float[3];
    private float total = 0;
    [SerializeField] private TextMeshProUGUI puntaje1; //carros
    [SerializeField] private TextMeshProUGUI puntaje2; //objetos
    [SerializeField] private TextMeshProUGUI puntaje3; //explosivos
    [SerializeField] private TextMeshProUGUI puntajeTotal;
    [SerializeField] private TextMeshProUGUI puntajeVista;
    //Contenedores informacion
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPuntaje;
    private CinemachineBrain cinematica;
    public bool gameEnd = false;
    private Cronometer time;
    private void Start()
    {
        time = FindObjectOfType<Cronometer>();
        cinematica = FindObjectOfType<CinemachineBrain>();
    }


    private void Update()
    {
        //segundos
        //puntos += Time.deltaTime; 
        //modificar el text ,solo enteros
        if (time.isGameOver)
        {
            MostrarPuntajeFinal();
        }
    }

    //posibles metodos para agregar los puntos
    public void SumarPuntos(float puntosTotales, int categoria)
    {
        if (!time.isGameOver)
        {
            puntos[categoria] += puntosTotales;
            total += puntosTotales;
            puntajeVista.text = "Puntos: " + total.ToString();
        }
    }
    //para activar el panel de los puntos
    public void MostrarPuntajeFinal()
    {
        cinematica.enabled = true;
        puntaje1.text = puntos[0].ToString(); 
        puntaje2.text = puntos[1].ToString(); 
        puntaje3.text = puntos[2].ToString(); 
        puntajeTotal.text = total.ToString();
        //puntaje1.text = puntos.ToString("0");
        buttonPause.SetActive(false);
        menuPuntaje.SetActive(true);
    }
}
