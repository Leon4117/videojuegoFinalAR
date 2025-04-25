using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private bool isNonExplosive;
    [SerializeField] private float valor = 10.0f;
    private int collisions = 0;
    private Puntaje pointSys;
    public AudioClip explosion;
    public AudioClip objeto;
    
    private AudioSource audioSonido;
    // Start is called before the first frame update
    void Start()
    {
        pointSys = FindObjectOfType<Puntaje>();
        audioSonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (explosionParticle != null)
            {
                GameObject antExp = GameObject.FindGameObjectWithTag("Explosion");
                if (antExp != null)
                {
                    audioSonido.PlayOneShot(explosion);
                    Destroy(antExp);
                }
                Instantiate(explosionParticle, gameObject.transform.position, gameObject.transform.rotation);
            }
            if (!isNonExplosive || collisions == 5)
            {
                audioSonido.PlayOneShot(objeto);
                Destroy(gameObject);
            }
            else
            {
                collisions++;
            }

            if (gameObject.tag.Equals("Explosive"))
            {
                pointSys.SumarPuntos(valor, 2);
            }
            else
            {
                pointSys.SumarPuntos(valor, 1);
            }
        }
    }
}
