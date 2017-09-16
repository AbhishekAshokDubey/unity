using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	private static int click_count = 0;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Animator> ().StartPlayback ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			click_count = click_count + 1;
			print ("Camera");
			if(click_count == 2){
				gameObject.GetComponent<Animator> ().speed = 0.5f;
				gameObject.GetComponent<Animator> ().StopPlayback ();				
			}
			if(click_count == 3){
				
			}
			/*
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			RaycastHit hit;
			if(Physics.Raycast(transform.position,fwd, out hit)){
				if(hit.collider.gameObject.name.ToLower() == "motor_back_body"){
					print ("motor hit");
					//Key key_cs = hit.collider.gameObject.GetComponent<Key>();
					//key_cs.OnKeyClicked ();
				}
			}*/
		}
	}
}
