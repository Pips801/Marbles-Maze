using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	/*
	 *	Rotation script.
	 *
	 *	Apply this script to any object that you want to rotate. Then, check the axis to rotate on.
	 *	
	 * 	NOTE: does not go negative, instead, use the reverse boolean.
	 * 
	 */

	// booleans
	public bool X;
	public bool Y;
	public bool Z;

	// is backwards
	public bool reverse;

	// speed
	public int speed;

	// private forces to be applied
	private float X_force = 0f;
	private float Y_force = 0f;
	private float Z_force = 0f;

	// Update is called once per frame
	void Update () {

		if (X)
			X_force = speed;

		if (Y)
			Y_force = speed;

		if (Z)
			Z_force = speed;

		// create new V3 with force data.
		Vector3 force = new Vector3 (X_force, Y_force, Z_force);

		// reverse the force
		if (reverse)
			force = force * -1;

		// apply the force
		transform.Rotate (force * Time.deltaTime * speed);

	}
}
