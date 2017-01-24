using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Char_Controlle : MonoBehaviour {

	private CharacterController character_controller;
	public Bounds move_bounds;

	// Use this for initialization
	void Start () {
		character_controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float y = 0;
		if (!character_controller.isGrounded) {
			y = -1;
		}
		var move_vec = new Vector3 (Input.GetAxis ("Horizontal"), y, Input.GetAxis ("Vertical"));
		if (!move_bounds.Contains (character_controller.transform.position + move_vec)) {
			move_vec.x = 0;
			move_vec.z = 0;
		}
		character_controller.Move (move_vec);

	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (move_bounds.center, move_bounds.size);
	}
}
