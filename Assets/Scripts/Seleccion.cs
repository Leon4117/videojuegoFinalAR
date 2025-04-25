using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para que salga en el menu
[CreateAssetMenu(fileName = "NuevoCarro", menuName="TipoCarro")]
//contenedores informacion
public class Seleccion : ScriptableObject
{
   
    public GameObject carroPosible;
    //los datos a cargar
    public Sprite imagen;
    public string nombre;
}
