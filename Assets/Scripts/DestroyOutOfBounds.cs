using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {
    private float topBoundX = 40.0f;
    private float lowerBoundX = 34.0f;
    private float topBoundZ = -10.0f;
    private float lowerBoundZ = -14.0f;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < topBoundX && transform.position.x > lowerBoundX) {
            if (transform.position.z < topBoundZ && transform.position.z > lowerBoundZ) {
                Destroy(gameObject);
            }
        }
    }
}
