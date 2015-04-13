using UnityEngine;
using System.Collections;

public class Blood : MonoBehaviour {

	private float lifeTime = 4;
	
	// Update is called once per frame
	void Update ()
	{
		//this just removes the blood after a few seconds
		lifeTime -= Time.deltaTime;
		
		if (lifeTime <= 0)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
