using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float xMin, xMax, zMin, zMax;
    public float speed;
    public float tilt;
    public int health;
    private Rigidbody Ship;
    public GameObject laserShot;
    public GameObject laserGun;
    public GameObject playerExp;
    public float shotDelay;
    float nextShotTime = 0;
    public static PlayerScript instance;

    void Start()
    {
        Ship = GetComponent<Rigidbody>();
        instance = this;
        health = 10;
    }
    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        Ship.velocity = new Vector3(moveX, 0, moveZ) * speed;

        float clampedX = Mathf.Clamp(Ship.position.x, xMin, xMax);
        float clampedZ = Mathf.Clamp(Ship.position.z, zMin, zMax);

        Ship.position = new Vector3(clampedX, 0, clampedZ);

        Ship.rotation = Quaternion.Euler(Ship.velocity.z * tilt, 0, -Ship.velocity.x * tilt);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed += 30f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed -= 30f;
        }

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(laserShot, laserGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Asteroid")
        {
            --health;
            Destroy(other.gameObject);
            if (health == 0)
            {
                Instantiate(playerExp, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameController.instance.gameOverPanel.SetActive(true);
            }
        }
    }
}
