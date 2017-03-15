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
	public GameObject rest_call_obj;
	private rest_calls r;
	
	// varibales below can be ignored
	public GameObject wheel;
	public GameObject wheel_rim;
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
		// random code below, can be ignored
		wheel.GetComponent<Animator> ().speed = 0.3f;
		materialColored = new Material (Shader.Find ("Diffuse"));
		materialColored.color = Color.green;
		wheel_rim.GetComponent<Renderer> ().material = materialColored;
		wheel.GetComponent<Animator> ().StopPlayback ();
	}
}
