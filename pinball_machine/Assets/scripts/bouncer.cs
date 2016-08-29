using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bouncer : MonoBehaviour {

	public float power;
	public float radius;
	public int duration; 
	public Material onhit_material;
	public Material original_material;

	private Vector3 exposition_position;
	private Renderer my_renderer;
	private int ticks;

	// Use this for initialization
	void Start () {
		exposition_position = transform.position;
		if (gameObject.tag != "wall") {
			my_renderer = GetComponent<Renderer> ();
			my_renderer.material = original_material;
		}
		ticks = 0;
	}

	void Update(){

		if (gameObject.tag == "wall") {
			return;
		}
		if (ticks != 0) {
			ticks--;
		} 
		else if (my_renderer.material != original_material) {
			my_renderer.material = original_material;	
		}
	}

	// Event for collsion
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag != "ball")
			return;
		//Vector3 contact_point = collision.contacts [0].normal;
		collision.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (power, exposition_position, radius, 3.0f);
//		Vector3 force_direction = collision.contacts[0].normal.normalized;
//		collision.gameObject.GetComponent<Rigidbody>().AddForce(force_direction.)

		if (gameObject.tag != "wall") {
			my_renderer.material = onhit_material;
			ticks = duration;
		}
	}
}
