using UnityEngine;
using System.Collections;

public class CameraLogic : MonoBehaviour {
	public Camera useCamera;
	public Transform trackObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//useCamera.transform.LookAt( trackObject );
		//useCamera.transform.position.Set(useCamera.transform.position.x,trackObject.transform.position.y, useCamera.transform.position.z);
		float x = useCamera.transform.position.x;
		float y = trackObject.transform.position.y;
		float z = useCamera.transform.position.z;
		
		//useCamera.transform.position.Set(x,y,z);
		useCamera.transform.position = new Vector3(x,y,z);
	}
}
