using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_motor : MonoBehaviour {


	public GameObject all_motor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onMotorClick(){
		print ("motor click");
		Animator all_motor_animator = all_motor.GetComponent<Animator>();
		rot_wheel all_motot_cs = all_motor.GetComponent<rot_wheel>();
		if (all_motot_cs.get_click_count() > 3) {
			all_motor_animator.SetBool ("onclick", true);
		}
	}
	public void onMotorFocus(){
		print ("motor11 enter");
	}
}
