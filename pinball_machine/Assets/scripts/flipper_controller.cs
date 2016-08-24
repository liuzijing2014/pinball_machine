using UnityEngine;
using System.Collections;

public class flipper_controller : MonoBehaviour {

	public float torque_force;
	public Vector3 torque_direction;

	void Update()
	{
		//float turn = Input.GetAxis("Jump");
		if (Input.GetButton ("Jump")) {
			print ("button pressed\n");
			GetComponent<Rigidbody>().AddTorque (0, -1000000,0 , ForceMode.Impulse);
		}
	}
}
