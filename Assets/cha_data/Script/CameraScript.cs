using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Vector3 offset;
    public GameObject player;
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);

    }
}
