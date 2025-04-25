using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    //Porque son componentes material
    public Material cloudy;
    public Material sunny;
    public Material night;
    //cambiar el sky box

    //modificar luces 
    public Light mainLight;
    public Light secLight;
    public Light terLight;

    public Color cloudyLi = new Color(0.5f, 0.5f, 0.6f);
    public Color sunnyLi = Color.white;
    public Color nightLi = new Color(0.2f, 0.2f, 0.3f);
    //luces del carro
    public Light[] carroLuces;
    public Light[] farosLuces;
    //particula de lluvia 
    public GameObject lluviaParti;
    public void ChangeSkybox(int weatherType)
    {
        switch (weatherType)
        {
            case 1:
                //se asigna el material al skybox
                Debug.Log("Nublado");
                //activa particula lluvia 
                lluviaParti.SetActive(true);
                //asigna cierta intensidad a las luces junto con el color
                mainLight.intensity = 0.8f;
                mainLight.color = cloudyLi;
                if (secLight != null) secLight.intensity = 0.3f;
                LucesCarro(1.0f, false);
                RenderSettings.skybox = cloudy;

                break;
            case 2:
                Debug.Log("Soleado");
                lluviaParti.SetActive(false);
                mainLight.intensity = 0.9f;
                mainLight.color = sunnyLi;
                if (secLight != null) secLight.intensity = 0.9f;
                if (terLight != null) terLight.intensity = 0.3f;
                LucesCarro(0.7f, false);
                RenderSettings.skybox = sunny;

                break;
            case 3:
                Debug.Log("Noshe");
                lluviaParti.SetActive(false);
                mainLight.intensity = 0.5f;
                mainLight.color = nightLi;
                if (secLight != null) secLight.intensity = 0.3f;
                terLight.intensity = 0.2f;
                LucesCarro(1.5f,true);
                
                RenderSettings.skybox = night;
                break;
            default:
                Debug.Log("No existe");
                break;

        }
        //Actualizar el clima
        DynamicGI.UpdateEnvironment();
    }
    public void LucesCarro(float intensidad)
    {
        foreach (var light in carroLuces) { 
            light.intensity = intensidad;
        }
    }
    public void LucesCarro(float intensidad, bool faros)
    {
        foreach (var light in carroLuces)
        {
            light.intensity = intensidad;
        }
        foreach (var light in farosLuces)
        {
            light.enabled = faros;
        }
    }
   

}