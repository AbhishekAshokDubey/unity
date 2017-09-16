using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
	public GameObject my_cube;
	public bool secondclick = false;
	public bool thirdclick = false;

	private Color currentColor;
	private Material materialColored;

	// Use this for initialization
	void Start () {
		my_cube.GetComponent<Animator> ().StartPlayback ();
	}
	
	// Update is called once per frame
	void Update () {
		//my_cube.GetComponent<Animator> ().StopPlayback ();
	}

	public void bikeClicked(){
		print ("clicked");
		if (secondclick && !thirdclick) {
			materialColored = new Material (Shader.Find ("Diffuse"));
			materialColored.color = Color.green;
			my_cube.GetComponent<Renderer> ().material = materialColored;
			my_cube.GetComponent<Animator> ().StopPlayback ();
			thirdclick = true;
			secondclick = true;
		} else if (thirdclick && secondclick) {
			my_cube.GetComponent<Animator> ().speed = 20.0f;
			materialColored = new Material (Shader.Find ("Diffuse"));
			materialColored.color = Color.red;
			my_cube.GetComponent<Renderer> ().material = materialColored;
			my_cube.GetComponent<Animator> ().StopPlayback ();
		} else if (!secondclick && !thirdclick) {
			secondclick = true;
		}
	}
}

