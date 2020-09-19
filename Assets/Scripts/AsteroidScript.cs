using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExp;
    public GameObject playerExp;
    public float rotationSpeed;
    [SerializeField] float minSpeed;
    public float maxSpeed;
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = new Vector3(0, 0, -Random.Range(minSpeed, maxSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid" || other.tag == "GameBoundary" || other.tag == "Enemy" )
        {
            return;
        }
        Instantiate(asteroidExp, transform.position, Quaternion.identity);
       
        if (other.tag == "Player")
        {
			Destroy(gameObject);
			return;
		}
		GameController.instance.score += 10;
        Destroy(gameObject);
        Destroy(other.gameObject);
        
    }

}
