using UnityEngine;
using System.Collections;

public class UILoadLevel : MonoBehaviour {

	public string sceneName;

	//handles the load level
	public void OnClick()
	{
		Application.LoadLevel (sceneName);
	}

}
