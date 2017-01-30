using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public float myGravity;
    public float myBaseJumpHeight;
    public int score;
    private Rigidbody rb;
    public float speed;
    private float elapsedTime = 0f;
    private bool end;

    private bool isDown;
    // Use this for initialization
    void Start () {
        score = 0;
        myGravity = 0.0f;
        myBaseJumpHeight = 8.0f;
        rb = GetComponent<Rigidbody>();
        elapsedTime = Time.time;
        end = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!end) 
        {
            score = (int)(Time.time - elapsedTime);
        }
        if (transform.position.y <= 0.5f) 
        {
           
            transform.position = new Vector3(0f, 1.1f, 0f);
            elapsedTime = Time.time;
        } 
    }
	void OnTriggerEnter(Collider other) {
        Debug.Log("Win");
        end = true;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), score.ToString());
    }
}
