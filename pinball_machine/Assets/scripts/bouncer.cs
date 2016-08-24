using UnityEngine;
using System.Collections;

public class bouncer : MonoBehaviour {

	public float power;
	public float radius;
	public int duration; 
	public Color onhit_color;
	public Color original_color;

	private Vector3 exposition_position;
	private Renderer my_renderer;
	private int ticks;

	// Use this for initialization
	void Start () {
		exposition_position = transform.position;
		if (gameObject.tag != "wall") {
			my_renderer = GetComponent<Renderer> ();
			my_renderer.material.color = original_color;
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
		else if (my_renderer.material.color != original_color) {
			my_renderer.material.color = original_color;	
		}
	}

	// Event for collsion
	void OnCollisionEnter(Collision collision) {
		collision.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (power, exposition_position, radius, 3.0f);
		if (gameObject.tag != "wall") {
			my_renderer.material.color = onhit_color;
			ticks = duration;
		}
	}
}
