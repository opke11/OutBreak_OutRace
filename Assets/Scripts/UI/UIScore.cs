using UnityEngine;
using System.Collections;

public class UIScore : MonoBehaviour {

	public UnityEngine.UI.Text text;

	//basic setting of the score text
	public void SetScore (int score)
	{
		text.text = score.ToString ("000");
	}
}
