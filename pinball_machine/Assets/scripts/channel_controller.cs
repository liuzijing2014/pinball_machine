using UnityEngine;
using System.Collections;

public class channel_controller : MonoBehaviour {

	public GameObject ball;
	public Transform position_1;
	public Transform position_2;
	public float force;
	public float wait_time;
	public game_manager my_gamemanager;

	private GameObject hit_object;
	private System.Type hit_type;
	private Vector3 pos_1;
	private Vector3 pos_2;

	void Start(){
		pos_1 = position_1.position;
		pos_2 = position_2.position;
	}

	// Use this for initialization
	void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "ball")
        {
            my_gamemanager.AddMoreLife(1);
        }
		hit_object = other.gameObject;
		pos_1.y = other.gameObject.transform.position.y;
		pos_2.y = other.gameObject.transform.position.y;
		hit_object.GetComponent<Collider> ().enabled = false;
		hit_object.GetComponent<Renderer> ().enabled = false;
		StartCoroutine(WaitAndSpawn(wait_time));
	}

	IEnumerator WaitAndSpawn(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		GameObject gobject_1 = (GameObject)Instantiate (hit_object, pos_1, position_1.rotation);
		GameObject gobject_2 = (GameObject)Instantiate (hit_object, pos_2, position_2.rotation);
		gobject_1.GetComponent<Collider> ().enabled = true;
		gobject_1.GetComponent<Renderer> ().enabled = true;
		gobject_2.GetComponent<Collider> ().enabled = true;
		gobject_2.GetComponent<Renderer> ().enabled = true;
		gobject_1.GetComponent<Rigidbody> ().AddForce (-position_1.right * force);
		gobject_2.GetComponent<Rigidbody> ().AddForce (-position_2.right * force);
		Destroy (hit_object);
	}
}
