using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyExp;
    public GameObject playerExp;
    public float minSpeed;
    public float maxSpeed;
    public GameObject laserShot;
    public GameObject laserGun;
    public float shotDelay;
    float nextShotTime = 0;
    void Start()
    {
        Rigidbody enemy = GetComponent<Rigidbody>();
        enemy.velocity = new Vector3(0, 0, -Random.Range(minSpeed, maxSpeed));
    }

    void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(laserShot, laserGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid" || other.tag == "GameBoundary" || other.tag == "Enemy")
        {
            return;
        }
        PlayerScript.instance.health -= 1;
        Instantiate(enemyExp, transform.position, Quaternion.identity);
        GameController.instance.score += 25;
        Destroy(gameObject);
    }

}
