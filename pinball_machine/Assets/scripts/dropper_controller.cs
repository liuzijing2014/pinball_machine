using UnityEngine;
using System.Collections;

public class dropper_controller : MonoBehaviour {

	public float down_distance;
	public float down_speed;
	public float up_speed;
	public float viberation;
	public float duration;

	private Vector3 down_position;
	private Vector3 original_position;
	private bool down;
	private float tick;
	void Start()
	{
		down_position = original_position = transform.position;
		down_position.y -= down_distance;
		down = false;
		tick = 0.0f;
	}

	// Event for collsion
	void OnCollisionEnter(Collision collision) {
		down = true;
		tick = duration;
		GetComponent<Collider> ().enabled = false;
	}

	void Update()
	{
		if (down) 
		{
			if (tick >= 0.0f) {
				float random = Random.Range (-viberation, viberation);
				Vector3 viberated_position = down_position;
				viberated_position.x += random;
				transform.position = Vector3.MoveTowards (transform.position, viberated_position, down_speed * Time.deltaTime);
				tick--;
			}
			else {
				if ((transform.position = Vector3.MoveTowards (transform.position, original_position, up_speed * Time.deltaTime)) == original_position) {
					down = false;
					GetComponent<Collider> ().enabled = true;
				}
			}
		}
	}
}
