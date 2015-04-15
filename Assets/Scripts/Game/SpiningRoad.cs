using UnityEngine;
using System.Collections;

public class SpiningRoad : MonoBehaviour {
	public float spinSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * spinSpeed * Time.smoothDeltaTime, Space.Self);
	}
}
