using UnityEngine;
using System.Collections;

public class triangle_bouncer : MonoBehaviour {

	public float applied_force;

	void Start(){
		gameObject.tag = "bouncer";
	}

	// Event for collsion
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag != "ball")
			return;
		collision.gameObject.GetComponent<Rigidbody> ().AddForce(transform.forward * applied_force);
	}
}
