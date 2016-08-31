using UnityEngine;
using System.Collections;

public class channel_controller : MonoBehaviour {

	public GameObject ball;
	public Transform position_1;
	public Transform position_2;
	public float force;
	public float wait_time;

	// Use this for initialization
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "ball") {
			Destroy (other.gameObject);
		}
		StartCoroutine(WaitAndSpawn(wait_time));
	}

	IEnumerator WaitAndSpawn(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		GameObject gobject_1 = (GameObject)Instantiate (ball, position_1.position, position_1.rotation);
		GameObject gobject_2 = (GameObject)Instantiate (ball, position_2.position, position_2.rotation);
		gobject_1.GetComponent<Rigidbody> ().AddForce (-position_1.right * force);
		gobject_2.GetComponent<Rigidbody> ().AddForce (-position_2.right * force);
	}
}
