using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset = new Vector3(0, 3, -10);  // Ajusta este offset según la distancia que quieras de la cámara
    private Vector3 offsetLight = new Vector3(-4.8f, 4, -2);  // Ajusta este offset según la distancia que quieras de la luz
    public bool isLight = false;
    private Cronometer time;

    // Rotación de la cámara para seguir al carro
    private Quaternion forwardRotation = Quaternion.Euler(-0.451f, 0f, 0f);
    private Quaternion reverseRotation = Quaternion.Euler(-0.451f, -180f, 0f);  // Rotación para ver hacia atrás

    private Quaternion lightsRotation = Quaternion.Euler(-0.451f, -93f, 0f);  // Rotación para luces

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        time = FindObjectOfType<Cronometer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isLight)
        {
            // Verifica si la tecla "S" está siendo presionada para decidir la rotación
            if (Input.GetKey(KeyCode.S) && !time.isGameOver)
            {
                transform.rotation = player.transform.rotation * reverseRotation;
            }
            else
            {
                transform.rotation = player.transform.rotation * forwardRotation;
            }
            // Ajusta la posición de la cámara con el offset
            transform.position = player.transform.position + transform.rotation * offset;
        }
        else
        {
            transform.rotation = player.transform.rotation * lightsRotation;
            // Ajusta la posición de la luz con el offset
            transform.position = player.transform.position + transform.rotation * offsetLight;
        }
    }
}
