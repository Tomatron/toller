using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BulletBeltLogic : MonoBehaviour {
	
	public List<GameObject> BulletSlots;
	
	public List<BaseBullet> BulletTypes;
	
	// FIXME!!
	public enum BulletType
	{
		Empty,
		Regular,
		Explosive,
		Fire,
	}
	
	int currentFireIndex = 0;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	public void ShowHighlight(GameObject slot)
	{
		/*int index = GetIndex(slot);
		if(index >= 0)
		{
			BulletSlots[index].renderer.enabled = true;
		}*/
	}
	
	public void HideHighlight(GameObject slot)
	{
		/*int index = GetIndex(slot);
		if(index >= 0)
		{
			BulletSlots[index].renderer.enabled = false;
		}*/
	}
	
	public void SetBulletType(int index, BulletType type)
	{
		if(type == BulletType.Empty)
		{
			BulletSlots[index].renderer.enabled = false;
		}
		else
		{
			BulletSlots[index].renderer.enabled = true;
		}
	}
	
	private int GetIndex(GameObject slot)
	{
		for(int i = 0; i < BulletSlots.Count; ++i)
		{
			if(BulletSlots[i] == slot)
				return i;
		}
		return -1;
	}
	
	public void AssignBulletType(BulletData data)
	{
		int index = GetIndex(data.beltSlotInstance_m);
		Debug.Log("!! Assigning belt : " + index);
		if(index >= 0)
		{
			SetBulletType(index, BulletType.Regular);
		}
	}
	
	
	/// <summary>
	/// Temporary means of resetting all the bullets and the
	/// 'fire' index.
	/// </summary> 
	public void ReloadBullets()
	{
		for(int i = 0; i < BulletSlots.Count; ++i)
		{
			SetBulletType(i, BulletType.Regular);
		}
		currentFireIndex = 0;
	}
	
	
	/// <summary>
	/// Hides the 'next' bullet in the belt.
	/// </summary>
	public void FireNextBullet()
	{
		if(currentFireIndex < BulletSlots.Count)
		{
			SetBulletType(currentFireIndex, BulletType.Empty);
			++currentFireIndex;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
