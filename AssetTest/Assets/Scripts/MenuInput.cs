using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {
	
	public GameObject BulletBelt;
	GameObject bulletUI_m;
	Vector3 bulletOrigin_m;
	Vector3 bulletDestination_m;
	float interpAmount_m = 0.0f;
	
	// State of the entire bullet selection
	enum State
	{
		IN,
		INTERP_IN,
		OUT,
		INTERP_OUT,
	}
	State state_m = State.OUT;
	
	// Use this for initialization
	void Start () {
		//Application.LoadLevelAdditive("canShoot");
	}
	
	void Update() 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			BulletBelt.SendMessage("FireNextBullet");
		}
		else if(Input.GetKeyDown(KeyCode.R))
		{
			BulletBelt.SendMessage("ReloadBullets");
		}
		else if(Input.anyKeyDown)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			RaycastHit raycast;
			bool b_hit = Physics.Raycast(ray, out raycast);
			if(b_hit)
			{
				GameObject obj = raycast.transform.gameObject;
				
				if(obj.CompareTag("BulletChamber"))
				{
					Debug.Log("Hit!");
					
					if(bulletUI_m == null)
					{
						bulletUI_m = obj;
						bulletOrigin_m = bulletUI_m.transform.localPosition;
						bulletDestination_m = new Vector3(0.0f, bulletOrigin_m.y, 0.0f);
					}
					
					if(state_m == State.OUT)
					{
						state_m = State.INTERP_IN;
					}
					else if(state_m == State.IN)
					{
						state_m = State.INTERP_OUT;
					}
				}
			}
		}
		
		// update interpolations
		if(state_m == State.INTERP_IN || state_m == State.INTERP_OUT)
		{
			float delta = Time.deltaTime * 2.0f;
			
			if(state_m == State.INTERP_IN)
			{
				interpAmount_m = Mathf.Clamp01(interpAmount_m + delta);
			}
			else if(state_m == State.INTERP_OUT)
			{
				interpAmount_m = Mathf.Clamp01(interpAmount_m - delta);
			}
			
			if(interpAmount_m == 0.0f)
			{
				state_m = State.OUT;
				Debug.Log("State: " + state_m);
			}
			else if(interpAmount_m == 1.0f)
			{
				state_m = State.IN;
				Debug.Log("State: " + state_m);
			}
			
			if(bulletUI_m != null)
			{
				bulletUI_m.transform.localPosition = Vector3.Lerp(bulletOrigin_m, bulletDestination_m, interpAmount_m);
			}
		}
	}
}
