using UnityEngine;
using System.Collections;

public class traffic_light_controller : MonoBehaviour {

	public float duration;
	public Color red_color;
	public Color green_color;
	public float offset;

	private Light my_light;
	private float ticks;
	// Use this for initialization
	void Start () {
		my_light = GetComponent<Light> ();
		ticks = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		ticks++;
		if (ticks == duration) {
			if (my_light.color == red_color) {
				my_light.color = green_color;
				Vector3 temp_pos = transform.position;
				temp_pos.x += offset;
				transform.transform.position = temp_pos;	
			} else {
				my_light.color = red_color;
				Vector3 temp_pos = transform.position;
				temp_pos.x -= offset;
				transform.transform.position = temp_pos;
			}
			ticks = 0.0f;
		}
	}
}
