using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincover : MonoBehaviour {
	public AnimationClip move;
	public Animation move1;
	// Use this for initialization
	void Start () {
		print ("clipppppppp");
		move.legacy = true;
		move1.clip = move;
		move1.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
