using UnityEngine;
using System.Collections;

public class flipper_controller : MonoBehaviour {

	public float torque_force;
    private int scale = 10000000;
	public int torque_direction;

	void Update()
	{
        //float turn = Input.GetAxis("Jump");
        if (Input.GetButton("Jump"))
        {
            //print ("button pressed\n");
            GetComponent<Rigidbody>().AddTorque(0, torque_direction * 10000 * torque_force, 0);
        }
    }
}
