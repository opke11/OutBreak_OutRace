using UnityEngine;
using System.Collections;

public class UIGameOver : MonoBehaviour {

	public UnityEngine.UI.Text score;
	public UnityEngine.UI.Text time;
	public UnityEngine.UI.Text bestScore;
	public UnityEngine.UI.Text bestTime;

	//sets the values in the game over screen
	public void Show (int endScore, float endTime, int endBestScore, float endBestTime)
	{
		gameObject.SetActive (true);

		score.text = endScore.ToString ("000");
		time.text = endTime.ToString ("0.00s");
		bestScore.text = endBestScore.ToString ("000");
		bestTime.text = endBestTime.ToString ("0.00s");
	}

	//back to title if button is pressed
	public void OnClick_Again()
	{
		Application.LoadLevel ("Title");
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//back to title if space is pressed
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel ("Title");
		}
	}
}
