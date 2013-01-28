using UnityEngine;
using System.Collections;

public class TimingCircleLogic : MonoBehaviour {
	
	float x = 1.0f;
	float y = 1.0f;
	
	bool bKeyDown = false;
	public CanLogic can;
	public GameObject targetImage;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.Space))
		{
			//if we're off...lets reset and turn ourselves on. mmm...hot
			if (renderer.enabled == false)
			{
				transform.localScale = new Vector3(4.0f, 4.0f, 0.01f);
				renderer.enabled = true;
				targetImage.renderer.enabled = true;
			}
			
			//key is totally being held down
			bKeyDown = true;
			
			//lets scale the big circle down a bit
			x = transform.localScale.x - 0.1f;
			y = transform.localScale.y - 0.1f;
		
			transform.localScale = new Vector3(x, y, 0.01f);
		}
		
		//on release
		if (Input.GetKeyUp(KeyCode.Space))
		{
			targetImage.renderer.enabled = false;
			renderer.enabled = false;
			can.HitCan(10.0f, Random.Range(5.0f, 20.0f));
		}
		
		//Debug.Log(x);
	}
}
