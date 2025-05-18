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
    private bool isDoublePointsActive = false;
    private float doublePointsTimer = 0f;
    private float pointsMultiplier = 1f; // Multiplicador normal
    private float basePoints = 0f; // Puntos base sin multiplicador
    [Header("Feedback de Puntos Dobles")]
    [SerializeField] private TextMeshProUGUI doublePointsFeedbackText;
    [SerializeField] private float feedbackDuration = 2f;
    private float feedbackTimer = 0f;
    void Start()
    {
        time = FindObjectOfType<Cronometer>();
        cinematica = FindObjectOfType<CinemachineBrain>();
    }


    private void Update()
    {
        if (isDoublePointsActive)
        {
            doublePointsTimer -= Time.deltaTime;
            if (doublePointsTimer <= 0)
            {
                isDoublePointsActive = false;
                pointsMultiplier = 1f;
            }
        }

        // Manejar el feedback visual
        if (feedbackTimer > 0)
        {
            feedbackTimer -= Time.deltaTime;
            if (feedbackTimer <= 0 && doublePointsFeedbackText != null)
            {
                doublePointsFeedbackText.gameObject.SetActive(false);
            }
        }
        
        if (time.isGameOver)
        {
            MostrarPuntajeFinal();
        }
    }

   private void ShowFeedback(string message)
    {
        if (doublePointsFeedbackText != null)
        {
            // Activa el objeto padre primero si es necesario
            if (!doublePointsFeedbackText.transform.parent.gameObject.activeSelf)
            {
                doublePointsFeedbackText.transform.parent.gameObject.SetActive(true);
            }
            
            doublePointsFeedbackText.text = message;
            doublePointsFeedbackText.gameObject.SetActive(true);
            feedbackTimer = feedbackDuration;
            
            // Forzar la actualización visual
            Canvas.ForceUpdateCanvases();
        }
        else
        {
            Debug.LogError("Feedback text no asignado!", this);
        }
    }

    public void ActivateDoublePoints(float duration)
    {
        // Siempre duplicar los puntos actuales al recoger el power-up
        for (int i = 0; i < puntos.Length; i++)
        {
            puntos[i] *= 2;
        }
        total *= 2;
        puntajeVista.text = "Puntos: " + total.ToString();

        // Activar o extender la duración de puntos dobles
        isDoublePointsActive = true;
        pointsMultiplier = 2f;
        doublePointsTimer += duration; // Suma el tiempo extra
        ShowFeedback("¡Puntos dobles!");
    }
    //posibles metodos para agregar los puntos
    public void SumarPuntos(float puntosTotales, int categoria)
    {
        if (!time.isGameOver)
        {
            float puntosFinales = puntosTotales * pointsMultiplier;
            puntos[categoria] += puntosFinales;
            total += puntosFinales;
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
