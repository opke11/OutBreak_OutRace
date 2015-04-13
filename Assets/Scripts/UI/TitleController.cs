using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {

	//used to handle input on the title screen

	void Start ()
	{
		//Screen.lockCursor = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//quits the application if ESC is hit
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		//starts the level if space is pressed
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel ("Game");
		}
	}
}
