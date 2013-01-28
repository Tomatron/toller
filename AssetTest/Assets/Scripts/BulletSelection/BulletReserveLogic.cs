using UnityEngine;
using System.Collections;

public class BulletReserveLogic : MonoBehaviour {
	
	private GameObject currentSlot_m;
	private GameObject currentBeltSlot_m;
	public GameObject BulletBelt;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject currentRayCast = null;
		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			RaycastHit raycast;
			bool b_hit = Physics.Raycast(ray, out raycast);
			if(b_hit)
			{
				GameObject obj = raycast.transform.gameObject;
				currentRayCast = obj;
				
				if(obj.CompareTag("BulletReserveSlot"))
				{
					if(currentSlot_m == null)// || currentSlot_m != obj)
					{
						obj.SendMessage("BecomeActive");
						currentSlot_m = obj;
					}
				}
				
				// Highlights a slot on the belt
				if(currentSlot_m != null && 
					obj.CompareTag("BulletBeltSlot"))
				{
					/*if(currentBeltSlot_m != null && currentBeltSlot_m != obj)
					{
						currentBeltSlot_m.transform.parent.SendMessage("ShowHighlighted",currentBeltSlot_m);
					}
					obj.renderer.enabled = true;*/
					currentBeltSlot_m = obj;
				}
			}
		}
		else
		{
			// Maps the reserve slot to the belt
			if(currentSlot_m != null & currentBeltSlot_m != null)
			{
				currentBeltSlot_m.transform.parent.SendMessage("AssignBulletType",
					new BulletData(currentBeltSlot_m, new BaseBullet()));
			}
			
			
			// reset shit when no input
			if(currentBeltSlot_m != null)
			{
				//currentBeltSlot_m.transform.parent.SendMessage("RemoveHighlight", currentBeltSlot_m);
				currentBeltSlot_m = null;
			}
			
			if(currentSlot_m != null)
			{
				currentSlot_m.SendMessage("BecomeInactive");
				currentSlot_m = null;
			}
		}
	}
}
