using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCamera : MonoBehaviour
{
    private Quaternion q;
    private float p = 0.0f;
    private Vector3 camPos;
    public float amount = 100.0f;
    public float amounty = 200.0f;
    [SerializeField] private GameObject apunta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (apunta == null)
        {
            apunta = GameObject.FindGameObjectWithTag("Player"); 
        }
        p += 0.1f;
        q = Quaternion.AngleAxis(p, Vector3.up) * Quaternion.AngleAxis(amounty, Vector3.right);
        camPos = q * Vector3.forward;
        camPos *= amount * 0.1f;
        camPos += apunta.transform.position;
        transform.position = camPos;
        transform.LookAt(apunta.transform.position);
    }
}
