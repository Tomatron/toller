using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	BulletChamberInput currentChamber_m;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.anyKeyDown)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			RaycastHit raycast;
			bool b_hit = Physics.Raycast(ray, out raycast);
			if(b_hit)
			{
				GameObject obj = raycast.transform.gameObject;
				
				if(obj.CompareTag("BulletChamber"))
				{
					BulletChamberInput input = obj.GetComponent<BulletChamberInput>();
					
					if(input != null)
					{
						//if(currentChamber_m != input)
						//{
							if(currentChamber_m != null)
								currentChamber_m.OnUnselect();
							currentChamber_m = input;
							input.OnSelect();
						//}
					}
				}
			}
		}
	}
}
