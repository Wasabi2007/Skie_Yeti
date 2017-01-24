using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour {

	public GameObject[] parts;
	public float start_speed=0.1f;
	public float acceleration = 0.001f;

	private List<GameObject> current_spawns = new List<GameObject>();

	// Use this for initialization
	void Start () {
		if (current_spawns.Count < 10) {
			var part = parts [Random.Range (0, parts.Length)];
			var spawn_z = (current_spawns.Count==0? 0: current_spawns [current_spawns.Count - 1].GetComponent<Renderer> ().bounds.max.z);
			spawn_z += part.GetComponent<Collider> ().bounds.extents.z-0.1f;
			var go = GameObject.Instantiate<GameObject> (part,new Vector3(0,0,spawn_z),part.transform.rotation);
			current_spawns.Add (go);
		}
	}

	// Update is called once per frame
	void Update () {
		if (current_spawns [0].GetComponent<Renderer> ().bounds.max.z < -10) {
			GameObject.Destroy (current_spawns [0]);
			current_spawns.RemoveAt (0);
		}

		foreach(var part in current_spawns){
			part.transform.position += Vector3.back * start_speed * Time.deltaTime;
		}
		start_speed += acceleration * Time.deltaTime;

		if (current_spawns.Count < 10) {
			var part = parts [Random.Range (0, parts.Length)];
			var spawn_z = current_spawns [current_spawns.Count - 1].GetComponent<Renderer> ().bounds.max.z;
			spawn_z += part.GetComponent<Renderer> ().bounds.extents.z-0.1f;

			var go = GameObject.Instantiate<GameObject> (part,new Vector3(0,0,spawn_z),part.transform.rotation);
			current_spawns.Add (go);
		}
		
	}
}
