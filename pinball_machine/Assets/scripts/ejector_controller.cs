using UnityEngine;
using System.Collections;

public class ejector_controller : MonoBehaviour {

	public string key;
	public float pullback_speed;
	public float stepback_speed;
	public float max_distance;
	public float push_force;
	public Rigidbody ball_rigidbody;
	public AudioClip engine_start;
	public AudioClip engine_stop;

	private Vector3 temp_pos;
	private Vector3 original_pos;
	private float back_distance;
	private bool shoot;
	private float percentage;
	private AudioSource source;

	void Start()
	{
		shoot = false;
		original_pos = GetComponent<Transform> ().position;
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () 
	{
		float back_distance = Mathf.Abs (transform.position.z - original_pos.z);

		if (Input.GetButton (key)) 
		{
			if (back_distance < max_distance) 
			{
				if (!source.isPlaying) {
					source.Play ();
				}
				transform.Translate (0.0f, 0.0f, -1 * pullback_speed * Time.deltaTime);
			} 
		}
		else
		{	
			transform.position = Vector3.MoveTowards (transform.position, original_pos, percentage * stepback_speed * Time.deltaTime);
		}

		if (Input.GetButtonUp(key)) {
			float distance = Mathf.Abs (transform.position.z - original_pos.z);
			percentage = distance / max_distance;
			if (shoot) 
			{
				ball_rigidbody.AddForce (0.0f, 0.0f, percentage * push_force);
			}
			shoot = false;
			source.Stop ();
			source.PlayOneShot (engine_stop, 0.65f);
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
