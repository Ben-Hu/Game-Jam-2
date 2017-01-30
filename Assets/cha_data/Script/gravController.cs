using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravController: MonoBehaviour {
	private AudioSource aud;
	private float audScaler = 1f;
	public float updateInterval = 0.5f;
	private float timeStamp = 0.0f;
	private Rigidbody rb;
	private float RMSValue = 0.0f;
	// Use this for initialization
	void Start () {
		//rb = this.GetComponent<Rigidbody>();
	}
	void FixedUpdate()
    {
    	//rb.AddForce(Physics.gravity * rigidbody.mass);
    }

	// Update is called once per frame
	void Update () {
		aud = this.GetComponent<AudioSource>();
		//Debug.Log(aud.clip.channels);
		
		float[] spectrum = new float[256];

		//Debug.Log(spectrum);
		for( int i = 1; i < spectrum.Length-1; i++ )
		{
			if (Time.time > timeStamp) 
			{	
				//Debug.Log(Math.Min(spectrum));
				//Debug.Log(Math.Max(spectrum));
				//Debug.Log(spectrum[i] * audScaler * 9.81f);
				//Magic Number *3
				float newGravity = 3.81f - (spectrum[i] * audScaler * 9.81f * 5f);
				if (newGravity < 0.3f)
				{
					newGravity = 0.3f;
				}
				//Debug.Log(newGravity);
				//Physics.gravity = new Vector3(0,-newGravity,0);
				timeStamp = Time.time + updateInterval;

				//AudioListener.GetSpectrumData( spectrum, 0, FFTWindow.Rectangular );
				//44100 Hz sample rate
				RMSValue = 0;
				float [] sample = new float[1024];
				//sample average dB value over the last 0.023 secs
				
				aud.GetOutputData(sample, 0);
				for(int j = 1; j < sample.Length-1; j++ )
				{
					sample[j] = sample[j] * sample[j];
				}
				for(int j = 1; j < sample.Length-1; j++ )
				{
					RMSValue += sample[j];
				}
				//Debug.Log(RMSValue);
				newGravity = Math.Max(10/Math.Max(RMSValue,1), 0.3f);
				//Debug.Log(newGravity);
				Physics.gravity = new Vector3(0, -newGravity, 0);
			}
		}

	}
}
