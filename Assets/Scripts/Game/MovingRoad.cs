using UnityEngine;
using System.Collections;

public class MovingRoad : MonoBehaviour {
	public float speed;
	public Transform[] pathPoints;

	private int i;

	// Use this for initialization
	void Start () {
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Move the road from point to point
		if (transform.position != pathPoints [i].position) {
			transform.position = Vector2.MoveTowards (transform.position, pathPoints [i].position, 
		                                          speed * Time.smoothDeltaTime);
		} else {
			i++; //set the next point
		}

		if (i >= pathPoints.Length) {
			i = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D c) {
		//Attach the player as child
		if (c.collider.gameObject.CompareTag ("Player")) {
			c.collider.gameObject.transform.parent = this.transform;
		}
	}

	void OnCollisionExit2D(Collision2D c) {
		//detach player when it leaves
		if (c.collider.gameObject.CompareTag ("Player")) {
			c.collider.gameObject.transform.parent = null;
		}
	}
}
