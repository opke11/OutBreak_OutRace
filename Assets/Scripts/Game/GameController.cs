using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private static readonly string KEY_BEST_SCORE = "BEST_SCORE";
	private static readonly string KEY_BEST_TIME = "BEST_TIME";

	public UITime timer;
	public UIScore score;
	public UIGameOver gameOver;
	public UISpeedNote speedNote;

	public float gameTime;
	public int gameScore;
	public int carSpeed;
	public bool gameFinished = false;

	public int bestScore;
	public float bestTime;

	// Use this for initialization
	void Start ()
	{
		//prevents cursor leaving the screen during gameplay, add back in when done
		//Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//checks if the game is over, preventing updates if it is
		if (gameFinished != true)
		{
			//hitting ESC during gameplay takes you back to the menu
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				//Screen.lockCursor = false;
				Application.LoadLevel ("Title");
			}

			//handles sending gametime and score to UI
			gameTime += Time.deltaTime;
			timer.SetTime (gameTime);
			score.SetScore (gameScore);
		}
	}

	//function for gameover
	public void GameOver ()
	{
		gameFinished = true;
		//Screen.lockCursor = false;

		//handles setting and getting the best score, for time and score
		bestScore = gameScore;
		bestTime = gameTime;
		if (PlayerPrefs.HasKey (KEY_BEST_SCORE))
		{
			var prevBestScore = PlayerPrefs.GetInt (KEY_BEST_SCORE);
			var prevBestTime = PlayerPrefs.GetFloat (KEY_BEST_TIME);
			if (gameScore > prevBestScore)
			{
				PlayerPrefs.SetInt (KEY_BEST_SCORE, gameScore);
				PlayerPrefs.SetFloat (KEY_BEST_TIME, gameTime);
			}
			else
			{
				bestScore = prevBestScore;
				bestTime = prevBestTime;
			}
		}
		else
		{
			PlayerPrefs.SetInt (KEY_BEST_SCORE, gameScore);
			PlayerPrefs.SetFloat (KEY_BEST_TIME, gameTime);
		}

		//ensures notification is hidden
		speedNote.Hide ();
		//shows the gameover screen, sends time and scores
		gameOver.Show (gameScore, gameTime, bestScore, bestTime);
	}
}
