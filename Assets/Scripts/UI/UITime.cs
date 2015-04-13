using UnityEngine;
using System.Collections;

public class UITime : MonoBehaviour {

	public UnityEngine.UI.Text text;

	//basic setting of time text
	public void SetTime (float time)
	{
		text.text = time.ToString ("0.00s");
	}
}
