using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MenuAbout : MonoBehaviour
{
    //del que creamos
    [SerializeField] private AudioMixer audioMixer;
   
    public float numVolumen = 0.75f;
    
    //controlar pantalla completa
    
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
   
    public void Volumen(float volumen)
    {
        numVolumen = volumen;
        audioMixer.SetFloat("Volumen",volumen);
    }
    public void AplicaVolum(float numVolumen)
    {
        
        audioMixer.SetFloat("Volumen", numVolumen);
    }
    public void AplicaVolum()
    {
        
        audioMixer.SetFloat("Volumen", numVolumen);
    }
    //setting->quality
    public void Calidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
