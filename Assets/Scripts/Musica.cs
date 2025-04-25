using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Musica : MonoBehaviour
{
    private static Musica  instance=null;
    public static Musica Instance {  get { return instance; } }
    //musica 
    public AudioClip lazyGeneration;
    public AudioClip alltheSmall;
    public AudioClip american;
    public AudioClip divaVirtual;
    public AudioClip itsGoing;
    public AudioClip numb;
    public AudioClip paranoid;
    public AudioClip savior;
    public AudioClip tokyoDrift;
    public AudioClip cancionRusa;

    public AudioClip menuMusic;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private MenuAbout about;
    public void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this.gameObject);
            return; 
        } else { 
            instance = this; 
        }
        DontDestroyOnLoad(this.gameObject); 
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = menuMusic;
    }
    public void Start()
    {
        about = FindObjectOfType<MenuAbout>();
    }
    private int TypeMusic()
    {
        int tipoMusi = 0;
        tipoMusi = Random.Range(1, 11);
        Debug.Log("No." + tipoMusi);
        return tipoMusi;
    }
    public void ElegirMusic()
    {
        DetenerMusic();
        switch (TypeMusic())
        {
            case 1:
                audioSource.clip = lazyGeneration;
                break;
            case 2:
                audioSource.clip = alltheSmall;
                break;
            case 3:
                audioSource.clip = american;
                break;
            case 4:
                audioSource.clip = divaVirtual;
                break;
            case 5:
                audioSource.clip = itsGoing;
                break;
            case 6:
                audioSource.clip = numb;
                break;
            case 7:
                audioSource.clip = paranoid;
                break;
            case 8:
                audioSource.clip = savior;
                break;
            case 9:
                audioSource.clip = tokyoDrift;
                break;
            case 10:
                audioSource.clip = cancionRusa;
                break;
            default:
                Debug.Log("Nop");
                break;
        }
        //comentenlo si no quieren musica
        about.AplicaVolum();
        audioSource.Play();
    }
    public void PausarMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
    public void ReanudarMusic()
    {      
            audioSource.UnPause();  
    }
    public void DetenerMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    
    public void CambiarMenu(AudioClip Music)
    {
        DetenerMusic();
        if (audioSource.clip != Music)
        { 
            audioSource.clip = Music;
            about.AplicaVolum();
            audioSource.Play();
        } 
    }
    }
