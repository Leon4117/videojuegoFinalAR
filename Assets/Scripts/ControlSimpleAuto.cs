using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSimpleAuto : MonoBehaviour
{
    [Header("Movimiento del Auto")]
    public float velocidad = 5f;
    public float rotacionVelocidad = 100f;

    [Header("Volante")]
    public Transform volante3D;
    public float anguloMaximoVolante = 450f;

    private float inputDireccion = 0f;

    void Update()
    {
        // Movimiento adelante/atrás
        float avance = Input.GetAxis("Vertical"); // W = 1, S = -1d
        transform.Translate(Vector3.forward * avance * velocidad * Time.deltaTime);

        // Dirección (giro)
        inputDireccion = Mathf.Lerp(inputDireccion, Input.GetAxis("Horizontal"), Time.deltaTime * 5f); // A = -1, D = 1
        transform.Rotate(Vector3.up * inputDireccion * rotacionVelocidad * Time.deltaTime);

        // Rotación del volante 3D
        if (volante3D != null)
        {
            float anguloVolante = inputDireccion * (anguloMaximoVolante / 2f);
            volante3D.localRotation = Quaternion.Euler(0f, 0f, -anguloVolante);
        }
    }
}
