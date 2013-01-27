using UnityEngine;
using System.Collections;

public class TextLogic : MonoBehaviour {
	
	public Transform canPos;
	
	public CanLogic can;
	bool bPrevInAir = false;
	float fStartTime = 0.0f;
	float fTimeDelta = 0.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//set height text
		guiText.text = "Height: " + canPos.transform.position.y.ToString() + "\n";
		
		//check if the air state has changed
		if (can.bInAir != bPrevInAir)
		{
			bPrevInAir = can.bInAir;
			if (can.bInAir == true)
			{
				fStartTime = Time.realtimeSinceStartup;
			}
		}
		
		//if we're in the air, update the timer
		if (can.bInAir == true)
		{
			fTimeDelta = Time.realtimeSinceStartup - fStartTime;
		}
		
		//display that time text, gangsta!
		guiText.text += "Time: " + fTimeDelta;
	
	}
}
