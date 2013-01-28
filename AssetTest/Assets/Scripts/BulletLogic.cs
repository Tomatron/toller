using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

	public GameObject prefab;
	public Camera camera;
	CanLogic can;
	
	public float maxForce;
	public float maxTorque;
	
	void CreateTimingCircle()
	{
		Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
		prefab.transform.parent = camera.transform;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.A))
		{
			CreateTimingCircle();
		}
		
	}
}
