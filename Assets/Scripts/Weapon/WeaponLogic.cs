using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{

    public Transform spawnPoint;

    public GameObject bullet;

    public float shotForce = 1500f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    private AudioSource audioSource;

    public AudioClip shotShound;

    public bool continueShooting = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0)
            {
                if (continueShooting)
                {
                    InvokeRepeating("Shoot", .001f, shotRate);
                }
                else
                {
                    Shoot();
                }


            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && continueShooting)
        {
            CancelInvoke("Shoot");
        }

    }


    public void Shoot()
    {

        if (GameManager.Instance.gunAmmo > 0)
        {


            if (audioSource != null)
            {
                audioSource.PlayOneShot(shotShound);
            }

            GameManager.Instance.gunAmmo--;

            GameObject newBullet;

            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

            shotRateTime = Time.time + shotRate;

            Destroy(newBullet, 5);

        }
        else
        {
            CancelInvoke("Shoot");
        }
    }
}
