using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graph1 : MonoBehaviour {
	public int resolution = 10;
	private ParticleSystem.Particle[] points;

	// Use this for initialization
	void Start () {
		points = new ParticleSystem.Particle[resolution];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}