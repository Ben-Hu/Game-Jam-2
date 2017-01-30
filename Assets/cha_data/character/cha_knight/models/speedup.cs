using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedup : MonoBehaviour {

	public float speed = 1f; 
	public Animation player; 

	
	// Update is called once per frame
	void Update () {

		player ["Walk"].speed = speed;
		
	}
}
