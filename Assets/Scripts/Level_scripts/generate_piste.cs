using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_piste : MonoBehaviour {

	public GameObject[] obstacles;
	public Vector2 grid_size = new Vector2(1,1);

	[Range(0,1)]
	public float placement_rate;

	// Use this for initialization
	void Start () {
		var collider = GetComponent<Collider> ();

		for (float x = collider.bounds.min.x; x < collider.bounds.max.x; x += grid_size.x)
			for (float z = collider.bounds.min.z; z < collider.bounds.max.z; z += grid_size.y)
				if (Random.value < placement_rate) {
					RaycastHit hit_info;
					if (Physics.Raycast (new Vector3 (x, collider.bounds.max.y, z), Vector3.down, out hit_info)) {
						var obstacle = obstacles [Random.Range (0, obstacles.Length)];
						var go = GameObject.Instantiate<GameObject> (obstacle, hit_info.point, obstacle.transform.rotation, transform);
						go.transform.localScale = Vector3.one*2;
					}
				}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
