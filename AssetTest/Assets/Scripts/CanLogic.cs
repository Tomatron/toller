using UnityEngine;
using System.Collections;

public class CanLogic : MonoBehaviour {
	
	public float fForce = 10.0f;
	public float fTorque = 10.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(new Vector3(0,fForce,0), ForceMode.Impulse);
			rigidbody.AddTorque(new Vector3(0,0,fTorque), ForceMode.Impulse);
		}
	
	}
}
