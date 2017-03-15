using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.IO;
using System;

[Serializable]
public class rest_data
{
	public string origin;
	public string url;
}

public class rot_wheel : MonoBehaviour {
	public GameObject wheel;
	public GameObject wheel_rim;
	public GameObject rest_call_obj;

	private bool secondclick = false;
	private bool thirdclick = false;
	private rest_calls r;

	private Color currentColor;
	private Material materialColored;

	// Use this for initialization
	void Start () {
		wheel.GetComponent<Animator> ().StartPlayback ();
		r = rest_call_obj.GetComponent<rest_calls> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			print ("mouse");
			motor_update ();
		}
	}

	public void func(){
		print (r.Results);
		rest_data data = JsonUtility.FromJson<rest_data> (r.Results);
		print (data.origin);
	}

	public void motor_update(){
		WWW w = r.GET("https://httpbin.org/get", func );

		print ("clicked");
		if (secondclick && !thirdclick) {
			wheel.GetComponent<Animator> ().speed = 0.3f;
			materialColored = new Material (Shader.Find ("Diffuse"));
			materialColored.color = Color.green;
			wheel_rim.GetComponent<Renderer> ().material = materialColored;
			wheel.GetComponent<Animator> ().StopPlayback ();
			thirdclick = true;
			secondclick = true;
		} else if (thirdclick && secondclick) {
			wheel.GetComponent<Animator> ().speed = 1.0f;
			materialColored = new Material (Shader.Find ("Diffuse"));
			materialColored.color = Color.red;
			wheel_rim.GetComponent<Renderer> ().material = materialColored;
			wheel.GetComponent<Animator> ().StopPlayback ();
		} else if (!secondclick && !thirdclick) {
			secondclick = true;
		}
	}
}
