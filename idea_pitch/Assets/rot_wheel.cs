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
	public GameObject wheel;
	public Texture my_image;
	//public GameObject wheel_rim;
	public GameObject back_wheel;
	public GameObject main_cover;
	public GameObject motor;
	public GameObject bar;
	public GameObject holder;
	//public AnimationClip move;

	private bool secondclick = false;
	private bool thirdclick = false;
	private rest_calls r;
	private bool show_img = false;
	private Color currentColor;
	private Material materialColored;
	private static int click_count = 0;

	public int get_click_count(){
		return click_count;
	}
	// Use this for initialization
	void Start () {
		wheel.GetComponent<Animator> ().StartPlayback ();
		back_wheel.GetComponent<Animator> ().StartPlayback ();
		back_wheel.GetComponent<Animator> ().StartPlayback ();
		r = rest_call_obj.GetComponent<rest_calls> ();
		gameObject.GetComponent<Animator> ().StartPlayback ();
		motor.GetComponent<Animator> ().StartPlayback ();
		holder.GetComponent<Animator> ().StartPlayback ();

		GameObject bar_chart_obj = GameObject.Find ("Barchart");
		GameObject line_chart_obj = GameObject.Find ("LineChartall");
		visibility (bar_chart_obj, false);
		visibility (line_chart_obj, false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//print ("mouse");
			click_count = click_count + 1;
			motor_update ();
		}	
		/*
		materialColored = new Material (Shader.Find ("Diffuse"));
		float delta = 20.0f * Time.deltaTime;
		print (delta);
		materialColored.color = new Color(0.0f+delta,0.0f,0.0f,1.0f);
		//materialColored.color = Color.red;
		motor.GetComponent<Renderer> ().material = materialColored;
		*/
	}

	public void func(){
		print (r.Results);
		rest_data data = JsonUtility.FromJson<rest_data> (r.Results);
		print (data.origin);
	}

	public void motor_update(){
		//print (click_count);
		//WWW w = r.GET("https://httpbin.org/get", func );

		//print ("clicked");

		if (click_count == 1) {
			back_wheel.GetComponent<Animator> ().speed = 0.3f;
			wheel.GetComponent<Animator> ().speed = 0.3f;
//			materialColored = new Material (Shader.Find ("Diffuse"));
//			materialColored.color = Color.green;
//			wheel_rim.GetComponent<Renderer> ().material = materialColored;
			wheel.GetComponent<Animator> ().StopPlayback ();
			back_wheel.GetComponent<Animator> ().StopPlayback ();
		}
		if (click_count == 2) {
			gameObject.GetComponent<Animator> ().StopPlayback ();
		}
//		if (click_count == 3) {
//			print ("3rd click");
			//GameObject main_cover = transform.Find ("main_cover").gameObject;
			//main_cover.GetComponent<Animation>().Play("move");
			//print (main_cover.GetComponent<Animation> ());
			//gameObject.GetComponentInChildren<Animation> ().Play ("move");
			//move.legacy = true;
			//move.S
			//main_cover.GetComponent<Transform> ().position = new Vector3 (0.0f, 1.0f, 0.0f);
//		}
		if (click_count == 3) {
			wheel.GetComponent<Animator> ().speed = 0.7f;
			back_wheel.GetComponent<Animator> ().speed = 0.7f;
//			materialColored = new Material (Shader.Find ("Diffuse"));
//			materialColored.color = Color.red;
//			wheel_rim.GetComponent<Renderer> ().material = materialColored;
			wheel.GetComponent<Animator> ().StopPlayback ();
			back_wheel.GetComponent<Animator> ().StopPlayback ();
			motor.GetComponent<Animator> ().speed = 0.5f;
			motor.GetComponent<Animator> ().StopPlayback ();
		}
		if(click_count == 4){
			//show_img = true;

			gameObject.GetComponent<Animator>().SetBool ("onclick", true);
			holder.GetComponent<Animator> ().StopPlayback ();

/*			float[] bar_values = { 2.0f,3.0f, 5.0f, 10.0f};
			Color[] color_values = { Color.red, Color.green, Color.blue, Color.grey };
			draw3DCharts (bar_values, color_values);
*/
			//visibility (gameObject, false);
			//visibility (GameObject.Find ("motor_back_body"), true);
			//visibility (GameObject.Find ("holder"), false);
		}
		if(click_count == 5){
			//show_img = false;
			//visibility (gameObject, true);
			//visibility (GameObject.Find ("holder"), true);
			GameObject bar_chart_obj = GameObject.Find ("Barchart");
			GameObject line_chart_obj = GameObject.Find ("LineChartall");
			visibility (bar_chart_obj, true);
			visibility (line_chart_obj, true);

			float[] bar_values = { 10.0f,7.0f, 6.0f, 4.0f};
			Color[] color_values = { Color.green, Color.yellow, Color.grey, Color.red};
			draw3DCharts (bar_values, color_values);

		}

	}

	public void visibility(GameObject g, bool display = true){
		Renderer[] r = g.GetComponentsInChildren<Renderer> ();
		foreach(Renderer rc in r){
			rc.enabled = display;
		}
	}

	public void draw3DCharts(float[] bar_values, Color[] color_values){
		List<GameObject> bars = new List<GameObject>();
		GameObject pos = GameObject.Find ("phm");
		List<Vector3> origin_list = new List<Vector3> ();
		origin_list.Add (new Vector3 (-11.0f, -72.99f, 38.78f));
		origin_list.Add (new Vector3 (-8.0f, -72.99f, 38.78f));
		origin_list.Add (new Vector3 (-5.0f, -72.99f, 38.78f));
		origin_list.Add (new Vector3 (-2.0f, -72.99f, 38.78f));

		//print (camera_pos);
		for(int i=0; i<bar_values.Length;i++){
			Vector3 pos_vec = pos.transform.position + new Vector3(2*i+1.0f, 1.0f,0);
			print (pos_vec);
			GameObject temp_bar = Instantiate (bar, origin_list[i] , Quaternion.identity);
			temp_bar.AddComponent<Rigidbody>();
			temp_bar.GetComponentInChildren<Renderer> ().material.color = color_values[i%color_values.Length];

			Vector3 y_scale = temp_bar.transform.localScale;
			y_scale.y = bar_values[i];
			temp_bar.transform.localScale = y_scale;
			bars.Add (temp_bar);
		}
	}
	public void OnGUI() {
		if (show_img) {
			if (!my_image) {
				print("Assign a Texture in the inspector.");
				return;
			}
			//GUI.DrawTexture(new Rect(40, 40, 220, 220), my_image, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(5, 5, 100, 100), my_image, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(150, 5, 100, 100), my_image, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(5, 150, 100, 100), my_image, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(150, 150, 100, 100), my_image, ScaleMode.ScaleToFit, true, 1.0F);		
		}
	}
}
