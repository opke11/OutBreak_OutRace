using UnityEngine;
using System.Collections;

public class UIScore : MonoBehaviour {

	public UnityEngine.UI.Text text;

	private int curScore;

	//basic setting of the score text
	public void SetScore (int score)
	{
		curScore += score;
		text.text = curScore.ToString ("000");
	}
}
