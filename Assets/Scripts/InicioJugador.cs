using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InicioJugador : MonoBehaviour
{
    private Weather weather;
    private Musica musica;
    [SerializeField] private SpawnManager spawnManagerScript;
    public GameObject player;

    public AudioClip ruidoCarro;

    private AudioSource audioSonido;

    private CinemachineBrain cinematica;
    private PrometeoCarController car;
    float remaining = 15;


    void Start()
    {
        // index jugador
        int indexCarro = PlayerPrefs.GetInt("SeleccionIndex");
        //la rotaci�n en la que lo quiero
        Quaternion rotacion = Quaternion.Euler(0, 90, 0);
        //la posicion que toma es la del objeto InicioJugador
        //intanciar el personaje, esta en game manager lista  le damos el index tomamos al prefab
        player = Instantiate(GameManager.Instance.seleccionsCar[indexCarro].carroPosible, transform.position, rotacion);
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        car = player.GetComponent<PrometeoCarController>();
        //nuevo clima
        //encontrar untania de un objeto, en este caso srcip
        weather = FindObjectOfType<Weather>();
        weather.ChangeSkybox(TypeSky());
        //para reprodur la musica
        Musica.Instance.audioSource.Stop();
        Musica.Instance.ElegirMusic();

        audioSonido = GetComponent<AudioSource>();
        audioSonido.PlayOneShot(ruidoCarro);
        spawnManagerScript = GameObject.FindObjectOfType<SpawnManager>();
        if (spawnManagerScript != null)
        {
            Debug.Log("SpawnManager encontrado. Configurando obst�culos.");
            spawnManagerScript.InvokeRepeating("SpawnObstacles", 2.0f, 2.0f);
            spawnManagerScript.isPlayStart = false;
        }
        else
        {
            Debug.LogError("SpawnManager no encontrado.");
        }

        cinematica = FindObjectOfType<CinemachineBrain>();
    }

    private void Update()
    {
        
        if(remaining <= 0)
        {
            cinematica.enabled = false;
            spawnManagerScript.isPlayStart = true;
            car.isPlayStart = true;
        }
        else
        {
            remaining -= Time.deltaTime;
        }
    }

    private int TypeSky()
    {
        int tipoCielo = 0 ;
        return tipoCielo = Random.Range(1,4);
    }

    
}
