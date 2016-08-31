using UnityEngine;
using System.Collections;

public class bottom_boundary_controller : MonoBehaviour {

	public game_manager my_gamemanager;

	void OnCollisionEnter(Collision collision) {
		Destroy (collision.gameObject);
		my_gamemanager.EndGame ();
	}
}
