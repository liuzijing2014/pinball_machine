using UnityEngine;
using System.Collections;

public class dropper_controller : MonoBehaviour {

	public float down_distance;
	public float down_speed;
	public float viberation;

	private Vector3 down_position;
	private bool down;
	void Start()
	{
		down_position = transform.position;
		down_position.y -= down_distance;
		down = false;
	}

	// Event for collsion
	void OnCollisionEnter(Collision collision) {
		down = true;
		GetComponent<Collider> ().enabled = false;
	}

	void Update()
	{
		if (down) 
		{
			float random = Random.Range (-viberation, viberation);
			Vector3 viberated_position = down_position;
			viberated_position.x += random;
			transform.position = Vector3.MoveTowards (transform.position, viberated_position, down_speed * Time.deltaTime);
		}
	}
}
