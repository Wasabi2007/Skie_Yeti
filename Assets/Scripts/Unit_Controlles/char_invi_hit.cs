using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_invi_hit : MonoBehaviour {

	public float invincibilty_time = 1;

	float countdown;


	void hit(){
		enabled = true;
		countdown = invincibilty_time;
		gameObject.layer = 9;
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown < 0) {
			gameObject.layer = 8;
			enabled = false;
		}
	}
}
