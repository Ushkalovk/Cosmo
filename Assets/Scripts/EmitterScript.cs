using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;
	public GameObject enemy;
    public float minDelay, maxDelay;
    private float nextLaunchTime = 0;  
	private float nextEnemyLaunchTime = 0;  

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Time.time > nextLaunchTime)
        {
            float emitterSize = transform.localScale.x;
            GameObject newAsteroid =  Instantiate(asteroid, new Vector3(Random.Range(-emitterSize / 2, emitterSize / 2), 0, transform.position.z), Quaternion.identity);
            newAsteroid.transform.localScale *= Random.Range(0.5f, 2);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
		if (Time.time > nextEnemyLaunchTime){
			float emitterSize = transform.localScale.x;
			Instantiate(enemy, new Vector3(Random.Range(-emitterSize / 2, emitterSize / 2), 0, transform.position.z), Quaternion.identity);
            nextEnemyLaunchTime = Time.time + Random.Range(minDelay*3, maxDelay*3);
		}
    }
}
