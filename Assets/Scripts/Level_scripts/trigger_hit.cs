using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_hit : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		collision.collider.gameObject.SendMessage ("hit", SendMessageOptions.DontRequireReceiver);
	}
}
