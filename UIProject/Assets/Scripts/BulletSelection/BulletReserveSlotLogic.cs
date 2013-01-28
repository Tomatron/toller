using UnityEngine;
using System.Collections;

public class BulletReserveSlotLogic : MonoBehaviour {
	
	Vector3 currentOffset_m = Vector3.zero;
	Vector3 mousePos_m = Vector3.zero;
	bool active_m = false;
	
	// Use this for initialization
	void Start () 
	{
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(active_m)
		{
			Vector3 mouseDelta = Input.mousePosition - mousePos_m;
			
		}
	}
	
	void BecomeActive()
	{
		renderer.enabled = true;
		active_m = true;
		
		currentOffset_m = transform.localPosition;
		mousePos_m = Input.mousePosition;
	}
	
	void BecomeInactive()
	{
		active_m = false;
		renderer.enabled = false;
	}
}
