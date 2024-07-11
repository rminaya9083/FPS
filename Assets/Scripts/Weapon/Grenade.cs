using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3;

    float countdown;

    public float radius = 5;

    public float explosionForce = 70;

    bool exploaded = false;

    public GameObject explotionEffect;


    private AudioSource audioSource;

    public AudioClip explosionSound;


    void Start()
    {
        countdown = delay;
        audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {

        countdown -= Time.deltaTime;

        if (countdown <= 0 && exploaded == false)
        {
            Explode();
            exploaded = true;
        }
        
    }

    void Explode()
    {
        Instantiate(explotionEffect,transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(var rangeObjects in colliders)
        {

            AI ai = rangeObjects.GetComponent<AI>();

            if (ai != null)
            {
                ai.GrenadeImpact();
            }

            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce * 10, transform.position, radius);
            }

        }

        audioSource.PlayOneShot(explosionSound);

        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        Destroy(gameObject,delay*2);
    }
}
