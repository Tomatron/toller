using UnityEngine;
using System.Collections;


public class BulletData : System.Object
{
	public GameObject beltSlotInstance_m;
	public BaseBullet bullet_m;
	
	public BulletData(GameObject slot, BaseBullet data)
	{
		beltSlotInstance_m = slot;
		bullet_m = data;
	}
}

public class BaseBullet : System.Object
{
	public BaseBullet()
	{
		
	}	
}


public class RegularBullet : BaseBullet
{
	
}


public class ExplosionBullet : BaseBullet
{
	
}