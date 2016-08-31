using UnityEngine;
using System.Collections;

public class ballsound_controller : MonoBehaviour {


	private AudioSource source;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "bouncer") {
			if (!source.isPlaying) {
				source.Play ();
			}
		}
	}
}
