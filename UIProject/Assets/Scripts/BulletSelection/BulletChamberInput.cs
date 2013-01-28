using UnityEngine;
using System.Collections;

public class BulletChamberInput : MonoBehaviour {
	
	public System.Collections.Generic.List<GameObject> Selections;
		
	enum State
	{
		INTERP_IN,
		IN,
		INTERP_OUT,
		OUT,
	}
	private State state_m = State.IN;
	private float interpAmount_m = 0.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void OnSelect()
	{
		// Interps the elements out
		//state_m = State.INTERP_OUT;
							if(state_m == State.IN || state_m == State.INTERP_IN)
					{
						Debug.Log(" Set state to interp out!");	
						state_m = State.INTERP_OUT;
					}
					else if(state_m == State.OUT || state_m == State.INTERP_OUT)
					{
						state_m = State.INTERP_IN;
						Debug.Log(" Set state to interp in!");	
					}
	}
	
	public void OnUnselect()
	{
		// Interps the elements in.
		state_m = State.INTERP_IN;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(Input.anyKeyDown)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
			RaycastHit raycast;
			bool b_hit = Physics.Raycast(ray, out raycast);
			if(b_hit)
			{
				if(raycast.transform.gameObject.CompareTag("BulletChamber") 
					&& raycast.transform.gameObject == gameObject)
				{
					Debug.Log("hit!");	
					if(state_m == State.IN || state_m == State.INTERP_IN)
					{
						Debug.Log(" Set state to interp out!");	
						state_m = State.INTERP_OUT;
					}
					else if(state_m == State.OUT || state_m == State.INTERP_OUT)
					{
						state_m = State.INTERP_IN;
						Debug.Log(" Set state to interp in!");	
					}
				}
			}
		}*/
		
					
		// Update interpolations
		if(state_m == State.INTERP_IN || state_m == State.INTERP_OUT)
		{
			float delta = Time.deltaTime * 2.0f;
			
			if(state_m == State.INTERP_IN)
			{
				interpAmount_m = Mathf.Clamp01(interpAmount_m - delta);
			}
			else if(state_m == State.INTERP_OUT)
			{
				interpAmount_m = Mathf.Clamp01(interpAmount_m + delta);
			}
			
			if(interpAmount_m == 0.0f)
			{
				state_m = State.IN;
				Debug.Log("State: " + state_m);
			}
			else if(interpAmount_m == 1.0f)
			{
				state_m = State.OUT;
				Debug.Log("State: " + state_m);
			}
			
			for(int i = 0; i < Selections.Count; ++i)
			{
				GameObject obj = Selections[i];
				//Vector3 offest = obj.transform.RotateAroundLocal(Vector3.left,);
				
				obj.transform.localPosition = interpAmount_m * obj.transform.forward;
				obj.transform.localScale = new Vector3(interpAmount_m, interpAmount_m, interpAmount_m);
			}
		}
	}
	
	
}
