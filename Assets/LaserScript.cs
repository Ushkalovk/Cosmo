using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed;
	public bool checkEnemy;
    void Start()
    {
		if(checkEnemy) speed = -speed;	
        GetComponent<Rigidbody>().velocity = new Vector3(0,0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
