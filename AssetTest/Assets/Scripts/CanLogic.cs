using UnityEngine;
using System.Collections;

public class CanLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(new Vector3(0,10,0), ForceMode.Impulse);
			rigidbody.AddTorque(new Vector3(0,0,10), ForceMode.Impulse);
		}
	
	}
}
