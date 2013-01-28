using UnityEngine;
using System.Collections;

public class CanLogic : MonoBehaviour {
	
	public float fForce = 10.0f;
	public float fTorque = 10.0f;
	
	public bool bInAir = false;
	
	public bool bPopIt = false;
	
	public int iDamageState = 0;
	
	public GameObject imagePlane;
	
	public Material mat_0;
	public Material mat_1;
	public Material mat_2;
	public Material mat_3;
	public Material mat_4;
	public Material mat_5;
	public Material mat_6;
	
	
	
	// Use this for initialization
	void Start () 
	{
		imagePlane.renderer.material = mat_0;
	}
	
	void OnCollisionExit(Collision theCollision)
	{
		bInAir = true;
	}
	
	void OnCollisionEnter(Collision theCollision)
	{
		bInAir = false;
	}
	
	void SetDamageState(int state)
	{
		//TODO: Make this function
		Material m = mat_0;
		
		if (state == 1)
			m = mat_1;
		else if (state == 2)
			m = mat_2;
		else if (state == 3)
			m = mat_3;
		else if (state == 4)
			m = mat_4;
		else if (state == 5)
			m = mat_5;
		else if (state == 6)
			m = mat_6;
		
		imagePlane.renderer.material = m;
		Debug.Log("Set the can texture.");
	}
	
	void ApplyForce(float force)
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.AddForce(new Vector3(0,force,0), ForceMode.Impulse);
	}
	
	void ApplyTorque(float torque)
	{
		rigidbody.AddTorque(new Vector3(0,0,torque), ForceMode.Impulse);
	}
	
	public void HitCan(float force, float torque)
	{
		if (iDamageState < 6)
		{
			ApplyForce(force);
			ApplyTorque(torque);
			
			++iDamageState;
			
			SetDamageState(iDamageState);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
