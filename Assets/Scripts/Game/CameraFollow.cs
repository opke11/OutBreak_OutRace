using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    GameController game = new GameController();

    Player CurrPlayer;

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = CurrPlayer.PlayerPos;
	
	}
}
