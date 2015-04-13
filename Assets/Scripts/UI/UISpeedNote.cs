using UnityEngine;
using System.Collections;

public class UISpeedNote : MonoBehaviour {

	//this script is used to flash text on the screen when called
	//modify this for any notifications you need

	public bool shown;
	public float time = 1;
	public float timer;

	public void Show ()
	{
		gameObject.SetActive (true);
		shown = true;
	}

	public void Hide ()
	{
		shown = false;
		timer = time;
		gameObject.SetActive (false);
	}

	// Use this for initialization
	void Start ()
	{
		timer = time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//uses a basic timer to hide again after a second
		if (shown == true && timer > 0)
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				Hide ();
			}
		}
	}
}
