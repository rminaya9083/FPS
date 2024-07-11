using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject enemyBullet;

    public Transform spawnBulletPoint;

    private Transform playerPosition;

    public float bulletVelocity = 100;



    
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;

        Invoke("ShootPlayer", 3);
    }

    
    void Update()
    {
        
    }


    void ShootPlayer()
    {
        Vector3 playerDirection = playerPosition.position - transform.position;

        GameObject newBulllet;

        newBulllet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);

        newBulllet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);

        Invoke("ShootPlayer", 3);
    }


}
