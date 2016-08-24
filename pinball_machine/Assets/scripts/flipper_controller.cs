using UnityEngine;
using System.Collections;

public class flipper_controller : MonoBehaviour {

	public float torque_force;
	public string key;
	public int torque_direction;
    
	private int scale = 100000000;
	private Rigidbody my_rigidbody;
	private HingeJoint my_hingejoint;

	void Start(){
		my_rigidbody = GetComponent<Rigidbody> ();
		my_hingejoint = GetComponent<HingeJoint> ();
	}


	void Update()
	{
        //float turn = Input.GetAxis("Jump");
		if (Input.GetButton (key)) 
		{
			//print ("button pressed\n");
			my_rigidbody.AddTorque (0, torque_direction * scale * torque_force, 0);
		} 
		else if(my_hingejoint.angle != my_hingejoint.limits.max || my_hingejoint.angle != my_hingejoint.limits.min)
		{
			my_rigidbody.AddTorque (0, torque_direction * scale * torque_force * -1, 0);
		}
    }
}
