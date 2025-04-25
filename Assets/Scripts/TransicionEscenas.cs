 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransicionEscenas : MonoBehaviour
{
    //para llamar mas rapido al metodo
    public static TransicionEscenas Instance;
    // efecto disolver variables
    [Header("Disolver")]
    //referencia al canvas
    public CanvasGroup disolverCanvasGroup;
    public float timeDisolver;
    public float timeDissolveSalida;

    //una instancia nula si no se destruye, inicializando el objeto
    //configuraciones iniciales que no dependen del scrip
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { 
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //pa´que se vea 
        DisolverEscena();    
    }

    private void DisolverEscena()
    {
        //modificar el alpha del canvas objeto
        // (objeto, valor que queremos el alfa, tiempo de transicion  ) 
        LeanTween.alphaCanvas(disolverCanvasGroup, 0f, timeDisolver).setOnComplete(() =>
            {
                //esto se ejecuta cuando termina la trancision 
                //habilia botones
                disolverCanvasGroup.blocksRaycasts = false;
                disolverCanvasGroup.interactable = false;
            }
        );
    }

    public void DisolverSalida(int indexEscena)
    {
        //habilita que NO pueda dar click a los botones
        disolverCanvasGroup.blocksRaycasts = true;
        disolverCanvasGroup.interactable= true;

        //cambiamos el alpha , de 1 a 0 
        LeanTween.alphaCanvas(disolverCanvasGroup, 2f, timeDissolveSalida).setOnComplete(() =>
        {
            //carga la escena que queremos
            SceneManager.LoadScene(indexEscena);
        }
        );
    }
}
