using UnityEngine;
using System.Collections;

public class vehicle_controller : MonoBehaviour {

	public Vector3 offsets;
	public float speed;
	public float wait_time;

	private Vector3 original_positon;
	private Vector3 target_position;
	private Vector3 end_position;
	private bool hold;
	private bool uturn;

	// Use this for initialization
	void Start () {
		original_positon = transform.position;
		target_position = end_position = original_positon + offsets;
		hold = false;
		uturn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (hold) {
			return;
		}

		if (transform.position != target_position) {
			transform.position = Vector3.MoveTowards (transform.position, target_position, speed * Time.deltaTime);
		} else {
			if (uturn) {
				return;
			}
			uturn = true;
			StartCoroutine(WaitAndGo(wait_time));
		}
	}

	IEnumerator WaitAndGo(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (target_position == end_position) {
			target_position = original_positon;
		} else {
			target_position = end_position;
		}
		uturn = false;
	}

	void OnCollisionEnter(Collision collision)
	{
			hold = true;
	}
}
