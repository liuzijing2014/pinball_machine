using UnityEngine;
using System.Collections;

public class ejector_controller : MonoBehaviour {

	public string key;
	public float pullback_speed;
	public float stepback_speed;
	public float max_distance;
	public float push_force;
	public Rigidbody ball_rigidbody;

	private Vector3 temp_pos;
	private Vector3 original_pos;
	private float back_distance;
	private bool hold;
	private bool shoot;
	private float percentage;

	void Start()
	{
		hold = false;
		shoot = false;
		original_pos = GetComponent<Transform> ().position;
	}

	// Update is called once per frame
	void Update () 
	{
		float back_distance = Mathf.Abs (transform.position.z - original_pos.z);
		if (Input.GetButtonUp(key)) {
			float distance = Mathf.Abs (transform.position.z - original_pos.z);
			percentage = distance / max_distance;
			if (shoot) 
			{
				ball_rigidbody.AddForce (0.0f, 0.0f, percentage * push_force);
			}
			shoot = false;
		}
		if (Input.GetButton (key)) 
		{
			if (back_distance < max_distance) 
			{
				transform.Translate (0.0f, 0.0f, -1 * pullback_speed * Time.deltaTime);
			} 
		}
		else
		{		
			transform.position = Vector3.MoveTowards (transform.position, original_pos, percentage * stepback_speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "ball") 
		{
			shoot = true;
		}	
	}
}
